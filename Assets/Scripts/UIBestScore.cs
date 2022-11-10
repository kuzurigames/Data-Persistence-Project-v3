using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBestScore : MonoBehaviour
{
    //I created this script to just handle the display of High Scores
    //It is attached to an on-screen UI
    public Text bestScoreText;
    //Drag the desired Text UI into this in the Inspector
    //I am using the legacy Text component (since the project uses it), which uses Text as class
    //Feel free to use TextMeshPro

    void Start()
    {
        //LOAD HIGH SCORE
        //if you don't load on start, this UI wouldn't know what the high score is
        MainManager.Instance.LoadHighScore();

        Debug.Log("High Score is " + MainManager.Instance.highScore);
        //optional. It's here to let me check things work

        //DISPLAY HIGH SCORE AND PLAYER
        if (MainManager.Instance != null)
        {
            if (MainManager.Instance.highScore != 0)
            {
                DisplayHighScore();
            }
            else
            {
                DisplayName();
            }
        }
        else
        {
            bestScoreText.text = "Hello, set a high score!";
        }

        //DISPLAY
        //This are leftover code when I was setting things up
        //Leaving it here so you can see it
        /*if (MainManager.Instance != null)
        {
            
            //DisplayName(MainManager.Instance.playerName);
        }
        else
        {
            DisplayName("Ash Ketchum");
        }
        */
    }

    void DisplayHighScore()
    {
        bestScoreText.text = MainManager.Instance.playerName + ", can you beat the High Score " + MainManager.Instance.highScore + " by " + MainManager.Instance.highScoreName + "?";
    }

    void DisplayName()
    {
        bestScoreText.text = MainManager.Instance.playerName + ", set a High Score!";
    }
}
