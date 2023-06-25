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
    private int CurrentPlayerNumber = 0;  // Used to show which player's turn it is.  
    

    private int CardspickedUp = 0; // Used in the pick up train cards action to keep track how many cards the player has picked.

    [SerializeField]
    public List<PlayerHand> players;  //List of the player's, by using CurrentPlayerNumber we can control who's turn it is and where to add cards and such.

    [SerializeField]
    private Transform OpenMarket; // Used to spawn the UI-train cards in the open market.
    public int PositionInHierarchy; // This is just used to replace the picked up train card in the open market.

    public UI_TrainCardsInfo CardClicked;

    [SerializeField]
    private GameObject NextPlayerButton;

    public RoutesScript roadToBuild;

    [SerializeField]
    public GameObject BuildButton;
    [SerializeField]
    public GameObject PickingCardsPanel;
    [SerializeField]
    private Transform SelectedCardsParent;
    [SerializeField]
    public GameObject ConfirmButton;

    public bool GoingToBuild = false;
    TrainCard_SO SelectedTC;
    [SerializeField]
    private GameObject Prefab_TC;

    [SerializeField]
    public Material PlayerOne;
    [SerializeField]
    public Material PlayerTwo;

    // Start is called before the first frame update
    void Start()
    {
        players.Add(cardManager.PlayerOne);   //Adds player's to the player's list
        players.Add(cardManager.PlayerTwo);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentPlayer = players[CurrentPlayerNumber];

        if (GoingToBuild == true)
        {
            if (CurrentPlayer.SelectedTrainCards.Count == roadToBuild.RequiredAmountofTrains)
            {
                ConfirmButton.SetActive(true);
            }
        }

        if (CurrentPlayer.ActionTaken == true)
        {
            NextPlayerButton.SetActive(true);
        }
        
    }


    public void PickUp_TC_Deck()  // Picking up from the deck.
    {
        if (CardspickedUp < 2 &&
            CurrentPlayer.ActionTaken == false)  // Checks if player can pick up.
        {
            TrainCard_SO topcard = cardManager.DeckofTrainCards_list[0];  // Sets topcard equal to card in the 0-position in DeckofTrainCards-list.
            cardManager.DeckofTrainCards_list.Remove(topcard); //Removes topcard from DeckofTrainCards-list
            CurrentPlayer.TrainCardsInHand.Add(topcard);  //Adds topcard to player's hand.
            CardspickedUp += 1;  
        }
        for (int i = 0; i < OpenMarket.childCount; i++)  // Checks to se if there are any locomotive cards in the open market.
        {
            Transform CheckLoco = OpenMarket.GetChild(i);

            if (CheckLoco.GetComponent<UI_TrainCardsInfo>().TrainCard.trainCardsType == TrainCard_SO.TypesOfTrainCards.Locomotives)
            {
                CheckLoco.GetComponent<UI_TrainCardsInfo>().CanPickUpAgain = false; //If a locomotive card is found, it prevents the player for picking it up for the its second card.
            }

            if (CardspickedUp == 2)  // if statement to check if the player has picked up the maximum amount of cards.
            {
                CurrentPlayer.ActionTaken = true;

            }

            if (CurrentPlayer.ActionTaken == true) // This sets the NextplayerButton active after the player has done their action.
            {
                NextPlayerButton.SetActive(true);
            }
        }

    }

    public void PickUp_MarketCard() // picking up from the open market.
    {

        if (CardspickedUp < 2 &&
            CurrentPlayer.ActionTaken == false) // Checks if player can pick up.
        {

           
           
            cardManager.openMarket_list.Remove(cardManager.openMarket_list[PositionInHierarchy]); // Removes the card from the open market list based on the position of the child under openMarket transform.


            CurrentPlayer.TrainCardsInHand.Add(CardClicked.TrainCard); //Adds the clicked traincard to the player's hand.
            cardManager.RefillMarket();

            CardspickedUp += 1;


            Debug.Log(CardClicked.TrainCard.trainCardsType);
            if (CardClicked.TrainCard.trainCardsType == TrainCard_SO.TypesOfTrainCards.Locomotives) // If train Card clicked was a Locomotive Card it ends player's turn. 
            {
                CurrentPlayer.ActionTaken = true;
                Debug.Log(CurrentPlayer.ActionTaken);
            }

            if (CardspickedUp == 2)  // if statement to check if the player has picked up the maximum amount of cards.
            {
                CurrentPlayer.ActionTaken = true;
                Debug.Log("hier");

            }

            if (CurrentPlayer.ActionTaken == true) // This sets the NextplayerButton active after the player has done their action.
            {
                NextPlayerButton.SetActive(true);
            }

            Debug.Log(CurrentPlayer.ActionTaken + " End");
        }

     }

    public void NextPlayer()  //Function called when NextPlayerturn is clicked.
    {
        if (CurrentPlayerNumber == 0)
        {
            CurrentPlayerNumber = 1;
          
        }

        else if (CurrentPlayerNumber == 1)
        {
            CurrentPlayerNumber = 0;
          
        }

        CurrentPlayer.BusyWithAction = false; //Resets bool
        CurrentPlayer.ActionTaken = false; // Resets bool
        CardspickedUp = 0; // Resets amount of cards picked up.
        NextPlayerButton.SetActive(false);

        for (int i = 0; i < OpenMarket.childCount; i++)
        {
            Transform CheckLoco = OpenMarket.GetChild(i);

             CheckLoco.GetComponent<UI_TrainCardsInfo>().CanPickUpAgain = true; //Resets the market cards to be picked up again.
           
        }

        Debug.Log(CurrentPlayer.PlayerName);
    }





    // Claiming a route

    public void SetButtonActive()
    {
        BuildButton.SetActive(true);
        GoingToBuild = true;
    }

    public void BuildingButton()
    {
       if (CurrentPlayer.BusyWithAction == false &&
            CurrentPlayer.ActionTaken   == false)
        {
            PickingCardsPanel.SetActive(true);
        }
        
       
    }

    public void PressCancel()
    {
        int Count = CurrentPlayer.SelectedTrainCards.Count;
        
        if (CurrentPlayer.SelectedTrainCards.Count != 0)
        {
            for (int i = 0; i < Count; i++)
            {
                TrainCard_SO PlaceCardBack = CurrentPlayer.SelectedTrainCards[0];
                CurrentPlayer.SelectedTrainCards.Remove(PlaceCardBack);
                CurrentPlayer.TrainCardsInHand.Add(PlaceCardBack);
            }

            for (int i = 0; i < Count; i++)
            {
                Destroy(SelectedCardsParent.gameObject.transform.GetChild(i).gameObject);
              
            }

        }

        PickingCardsPanel.SetActive(false);
        ConfirmButton.SetActive(false);
        GoingToBuild = false;
    }

    public void AddCardToSelectedList()
    {

        SelectedTC = CardClicked.TrainCard;

        if (roadToBuild.RouteColour == TrainCard_SO.TypesOfTrainCards.None)
        {
            if (CurrentPlayer.SelectedTrainCards.Count == 0)
            {
                
                CurrentPlayer.SelectedTrainCards.Add(SelectedTC);
                CurrentPlayer.TrainCardsInHand.Remove(SelectedTC);
                SelectedCardsDisplay();
            }

            else
            {
                if (SelectedTC == CurrentPlayer.SelectedTrainCards[0] ||
                    SelectedTC.trainCardsType == TrainCard_SO.TypesOfTrainCards.Locomotives)
                {
                    CurrentPlayer.SelectedTrainCards.Add(SelectedTC);
                    CurrentPlayer.TrainCardsInHand.Remove(SelectedTC);
                    SelectedCardsDisplay();
                }
            }
        }

        else
        {
            if (SelectedTC.trainCardsType == roadToBuild.RouteColour ||
                SelectedTC.trainCardsType == TrainCard_SO.TypesOfTrainCards.Locomotives)
            {
                CurrentPlayer.SelectedTrainCards.Add(SelectedTC);
                CurrentPlayer.TrainCardsInHand.Remove(SelectedTC);
                SelectedCardsDisplay();
            }
        }
        
    }

    public void SelectedCardsDisplay()
    {
        Prefab_TC.GetComponent<UI_TrainCardsInfo>().TrainCard = SelectedTC;
        Instantiate(Prefab_TC, SelectedCardsParent);
    }

    public void PressinConfirmButton()
    {
        CurrentPlayer.WoodenTrains -= roadToBuild.RequiredAmountofTrains;
            
            if (CurrentPlayer.WoodenTrains >= 0)
        {
            int Count = CurrentPlayer.SelectedTrainCards.Count;

            for (int i = 0; i < Count; i++)
            {
                TrainCard_SO PlaceInDiscard = CurrentPlayer.SelectedTrainCards[0];
                CurrentPlayer.SelectedTrainCards.Remove(PlaceInDiscard);
                cardManager.Discardpile_TrainCards_list.Add(PlaceInDiscard);

            }

            

            for (int i = 0; i < Count; i++)
            {
                Destroy(SelectedCardsParent.gameObject.transform.GetChild(i).gameObject);

            }

            roadToBuild.Owned = true;
            roadToBuild.Owner.PlayerName = CurrentPlayer.PlayerName;
            roadToBuild.ApplyPlayerColour();

            switch (roadToBuild.RequiredAmountofTrains)
            {
                case 1:
                    {
                        CurrentPlayer.PlayerScore += 1;
                        break;
                    }

                case 2:
                    {
                        CurrentPlayer.PlayerScore += 2;
                        break;
                    }

                case 3:
                    {
                        CurrentPlayer.PlayerScore += 4;
                        break;
                    }

                case 4:
                    {
                        CurrentPlayer.PlayerScore += 7;
                        break;
                    }

                case 5:
                    {
                        CurrentPlayer.PlayerScore += 10;
                        break;
                    }

                case 6:
                    {
                        CurrentPlayer.PlayerScore += 15;
                        break;
                    }

                    
            }

            PickingCardsPanel.SetActive(false);
            ConfirmButton.SetActive(false);
            GoingToBuild = false;
            CurrentPlayer.ActionTaken = true;
            BuildButton.SetActive(false);
        }

            else
        {
            CurrentPlayer.WoodenTrains += roadToBuild.RequiredAmountofTrains;
            Debug.Log("Can't afford");
        }
    }
}
