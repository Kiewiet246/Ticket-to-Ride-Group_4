using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

// Applies the scriptable objects(trainCards) information to gameObjects and the UI.

[Serializable]
public class UI_TrainCardsInfo : MonoBehaviour
{
    [SerializeField]
    public TrainCard_SO TrainCard;


    [SerializeField]
    Image image;

  
    public void Update()
    {
        
        image.sprite = TrainCard.sprite;
    }

    public void LogMessage(string message)
    {
        Debug.Log(message);
    }

}
