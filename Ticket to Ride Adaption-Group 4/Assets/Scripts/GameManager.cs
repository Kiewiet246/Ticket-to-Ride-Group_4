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
    public PlayerHand CurrentPlayer;

   [SerializeField]
    private int CurrentPlayerNumber = 0;   
    

    private int CardspickedUp = 0;

    [SerializeField]
    public List<PlayerHand> players;  //List of the player's, by using CurrentPlayerNumber we can control who's turn it is and where to add cards and such.

    [SerializeField]
    private Transform OpenMarket;
    public int PositionInHierarchy;

    public UI_TrainCardsInfo CardClicked;

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

    public void PickUp_MarketCard()
    {

        if (CardspickedUp < 2 &&
            CurrentPlayer.ActionTaken == false)
        {
            CardClicked.TrainCard = cardManager.openMarket[PositionInHierarchy];
            cardManager.openMarket.Remove(CardClicked.TrainCard);
            CurrentPlayer.TrainCardsInHand.Add(CardClicked.TrainCard);
            cardManager.RefillMarket();

            CardspickedUp += 1;
            
            if (CardClicked.TrainCard.trainCardsType == TrainCard_SO.TypesOfTrainCards.Locomotives)
            {
                CurrentPlayer.ActionTaken = true;
            }
        }

        

       

    }
}
