using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //I renamed this from MainManager to GameManager because all the code actually controls the game
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public GameObject GameOverText;
    //private string playerName;

    private bool m_Started = false;
    private int m_Points;

    private bool m_GameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }


    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
        CheckBestPlayer();

    }

    //CHECK IF PLAYER HAS BEAT HIGH SCORE
    void CheckBestPlayer()
    {
        //IF PLAYER BEATS HIGH SCORE, SAVE THEIR NAME AND HIGH SCORE
        if (m_Points > MainManager.Instance.highScore)
        {
            //Set MainManager to the new high score and name
            MainManager.Instance.highScore = m_Points;
            MainManager.Instance.highScoreName = MainManager.Instance.playerName;

            //This is the actual function that does the saving to MainManager
            MainManager.Instance.SaveHighScore(MainManager.Instance.highScore, MainManager.Instance.highScoreName);

            //Debug Log for my own testing
            Debug.Log("New high score " + MainManager.Instance.highScore);

        }
        else
        {
            //DON'T DO ANYTHING
        }


    }

}