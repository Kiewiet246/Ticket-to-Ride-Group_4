using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


// Will control the actions the players can take.
[Serializable]
public class GameManager : MonoBehaviour
{
    public CardManager cardManager;
    private PlayerHand CurrentPlayer;

   [SerializeField]
    private int CurrentPlayerNumber = 0;
    

    private int CardspickedUp = 0;

    [SerializeField]
    public List<PlayerHand> players;

    // Start is called before the first frame update
    void Start()
    {
        players.Add(cardManager.PlayerOne);
        players.Add(cardManager.PlayerTwo);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentPlayer = players[CurrentPlayerNumber];


        if (CardspickedUp == 2)
        {
            CurrentPlayer.ActionTaken = true;
        }
    }


    public void PickUp_TC_Deck()
    {
        if (CardspickedUp < 2 &&
            CurrentPlayer.ActionTaken == false)
        {
            TrainCard_SO topcard = cardManager.DeckofTrainCards[0];
            cardManager.DeckofTrainCards.Remove(topcard);
            CurrentPlayer.TrainCardsInHand.Add(topcard);
            CardspickedUp += 1;
        }
       

    }

}
