using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CurrentPlayerUI : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    private Text NameOfPlayer;
    [SerializeField]
    private Text Playerscore;
    [SerializeField]
    private Text Playertrains;

    // Update is called once per frame
    void Update()
    {
        NameOfPlayer.text = gameManager.CurrentPlayer.PlayerName;
        Playerscore.text = "Score:" +gameManager.CurrentPlayer.PlayerScore.ToString();
        Playertrains.text = "Trains:" + gameManager.CurrentPlayer.WoodenTrains.ToString();
    }
}
