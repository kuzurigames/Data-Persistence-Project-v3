using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayerDetails : MonoBehaviour
{
    //I created this soley to store Player name
    //This is called upon by my on-screen Text Field On End Edit()
    private string input;

    public void StorePlayerName(string inputName)
    {
        //Store player
        //input = inputName;
        Debug.Log(inputName);

        MainManager.Instance.playerName = inputName;
    }
}