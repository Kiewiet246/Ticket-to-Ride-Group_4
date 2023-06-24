using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

// Manages the cards, both Train Cards and Destination cards. It creates the decks, shuffles and deals the cards. Creates the Open Market and checks if the open market has 3 locomotive cards.

[Serializable]
public class CardManager : MonoBehaviour
{
    [SerializeField]
    private TrainCard_SO[] TrainCards_So; //USed to add the scriptable objects in the inspector.
    [SerializeField]
    private TrainCard_SO LocomotiveCard; //USed to add the scriptable objects in the inspector.


    [SerializeField]
    public List<TrainCard_SO> DeckofTrainCards_list; // This list will be the deck of train cards.
    [SerializeField]
    List<TrainCard_SO> Discardpile_TrainCards_list; // The discard pile.


    [SerializeField]
    public List<TrainCard_SO> openMarket_list; //The open market

    private int CountLoco =0; //int to keep track of how many Locomotive cards are in the open market.

    [SerializeField]
    private Transform OMparent; // Used to spawn the UI-train cards in the open market.
    [SerializeField]
    private GameObject Prefab_TC_UI; // Prefab use to spawn in the Ui for train cards. Scriptable objects info is applied to this.
   // private TrainCard_SO TCFORUi;

    [SerializeField]
    public PlayerHand PlayerOne;
    [SerializeField]
    public PlayerHand PlayerTwo;

    [SerializeField]
    public List<DestinationCards_SO> DestCardsDeck; // List of destination cards.

    private GameObject InstantiateThisObject;

   // [SerializeField]
    // MarketCardClickable cardClickable;
    [SerializeField]
    private GameManager gameManager_CardM;

  
    
    

    private void Awake()
    {
        
        

        CreateDeck();
        ShuffleTrainCards(); 
        DealCardsTrainCards();
        OpenMarket();

        ShuffleDestCards();
        DealDC();

      
    }

    public void Update()
    {
        
    }

    public void CreateDeck()
    {
        DeckofTrainCards_list = new List<TrainCard_SO>();
      
        foreach (TrainCard_SO TrainCard in TrainCards_So)
        {
           for (int i = 0; i < 12; i++)
            {
                DeckofTrainCards_list.Add(TrainCard);
                //TrainCard.ClickedInMarket = false;
            }
        }

        for (int i = 0; i < 14; i++)
        {
            DeckofTrainCards_list.Add(LocomotiveCard);
           // LocomotiveCard.ClickedInMarket = false;
        }

      
    }

    public void ShuffleTrainCards()
    {
        int Length = DeckofTrainCards_list.Count;
        int HalfLength = DeckofTrainCards_list.Count / 2;
        for (int i = 0; i < HalfLength; i++)
        {
            int randomIntegerA = UnityEngine.Random.Range(0, Length);
            int randomIntegerB = UnityEngine.Random.Range(0, Length);
            SwapOnDeckTC(randomIntegerA, randomIntegerB);
        }
    }

    private void SwapOnDeckTC(int indexA, int indexB)
    {
        TrainCard_SO elementA = DeckofTrainCards_list[indexA];
        TrainCard_SO elementB = DeckofTrainCards_list[indexB];
        DeckofTrainCards_list[indexA] = elementB;
        DeckofTrainCards_list[indexB] = elementA;
    }


    private void DealCardsTrainCards()
    {
        PlayerOne.TrainCardsInHand = new List<TrainCard_SO>();

        for (int i = 0; i < 4; i++)
        {
            TrainCard_SO topCard = DeckofTrainCards_list[0];
            DeckofTrainCards_list.Remove(topCard);
            PlayerOne.TrainCardsInHand.Add(topCard);
        }

        PlayerTwo.TrainCardsInHand = new List<TrainCard_SO>();

        for (int i = 0; i < 4; i++)
        {
            TrainCard_SO topCard = DeckofTrainCards_list[0];
            DeckofTrainCards_list.Remove(topCard);
            PlayerTwo.TrainCardsInHand.Add(topCard);
        }
    }
    
    
    
    
    
    public void OpenMarket()
    {
        openMarket_list = new List<TrainCard_SO>();
        
        for (int i =0; i< 5; i++)
        {
            TrainCard_SO topCard = DeckofTrainCards_list[0];
            DeckofTrainCards_list.Remove(topCard);
            openMarket_list.Add(topCard);
            Prefab_TC_UI.GetComponent<UI_TrainCardsInfo>().TrainCard = topCard;
            InstantiateThisObject = Prefab_TC_UI;
            InstantiateThisObject = Instantiate(Prefab_TC_UI, OMparent);
            InstantiateThisObject.AddComponent<MarketCardClickable>();
            InstantiateThisObject.GetComponent<MarketCardClickable>().gameManager_Clickable = gameManager_CardM;
            //Test.GetComponent<UI_TrainCardsInfo>().CanPickUpAgain = true;

            // Prefab_TC_UI.GetComponent<UI_TrainCardsInfo>().TrainCard = topCard;
        }
       
        CheckingMarket();
    }


    public void RefillMarket()
    {
        Debug.Log(DeckofTrainCards_list[0] + " Topcard");
        

            TrainCard_SO topCard = DeckofTrainCards_list[0];
        DeckofTrainCards_list.Remove(topCard);
        
        
        openMarket_list.Insert(gameManager_CardM.PositionInHierarchy, topCard);

       

        Prefab_TC_UI.GetComponent<UI_TrainCardsInfo>().TrainCard = topCard;
        InstantiateThisObject = Prefab_TC_UI;
       InstantiateThisObject = Instantiate(Prefab_TC_UI, OMparent);
        InstantiateThisObject.gameObject.transform.SetSiblingIndex(gameManager_CardM.PositionInHierarchy);
        
        InstantiateThisObject.AddComponent<MarketCardClickable>();
        InstantiateThisObject.GetComponent<MarketCardClickable>().gameManager_Clickable = gameManager_CardM;
        Debug.Log(InstantiateThisObject.GetComponent<UI_TrainCardsInfo>().TrainCard.CardName + " card under OMparent");
        
        foreach (Transform OMchild in OMparent)
        {
            OMchild.GetComponent<UI_TrainCardsInfo>().TrainCard = openMarket_list[OMchild.GetSiblingIndex()];
        }




        if (topCard.trainCardsType == TrainCard_SO.TypesOfTrainCards.Locomotives)
        {
            InstantiateThisObject.GetComponent<UI_TrainCardsInfo>().CanPickUpAgain = false;
        }
         
        
        else if (topCard.trainCardsType != TrainCard_SO.TypesOfTrainCards.Locomotives)
        {
           
            foreach (Transform OMchild in OMparent)
            {
                if (OMchild.GetComponent<UI_TrainCardsInfo>().TrainCard.trainCardsType == TrainCard_SO.TypesOfTrainCards.Locomotives)
                {
                    OMchild.GetComponent<UI_TrainCardsInfo>().CanPickUpAgain = false;
                }
            }

            //for (int i = 0; i < OMparent.childCount; i++)
            //{



            //  Transform CheckLoco = OMparent.GetChild(i);
            //   Debug.Log("Checking " + CheckLoco.GetComponent<UI_TrainCardsInfo>().TrainCard.CardName + " " + i);
            //  Debug.Log(openMarket_list[i] + "After CheckLoco");

            //  if (CheckLoco.GetComponent<UI_TrainCardsInfo>().TrainCard.trainCardsType == TrainCard_SO.TypesOfTrainCards.Locomotives)
            //  {
            //  CheckLoco.GetComponent<UI_TrainCardsInfo>().CanPickUpAgain = false;
            //}
            // }
        }

        CheckingMarket();
    }

    

  
    
    
    public void CheckingMarket()
    {
        foreach (TrainCard_SO openCard in openMarket_list)
        {
           if (openCard == LocomotiveCard)
            {
               
                CountLoco += 1;
                
                
            }

           
        }

        if (CountLoco >= 3)
        {
            ClearingOpenMarket();
            
            CountLoco = 0;

            Debug.Log("Restock");
            OpenMarket();
        }
        
        CountLoco = 0;
        



    }

    public void ClearingOpenMarket()
    {
       
        
        for (int i = 0; i < 5; i++)
        {
            TrainCard_SO FirstCard = openMarket_list[0];
            openMarket_list.Remove(FirstCard);
            Discardpile_TrainCards_list.Add(FirstCard);
            
        }

        for (int i = 0; i < OMparent.childCount; i++)
        {
            Transform CheckLoco = OMparent.GetChild(i);
            Destroy(CheckLoco.gameObject);
        }


    }

    public void ShuffleDestCards()
    {
        int Length = DestCardsDeck.Count;
        int HalfLength = DestCardsDeck.Count / 2;
        for (int i = 0; i < HalfLength; i++)
        {
            int randomIntegerA = UnityEngine.Random.Range(0, Length);
            int randomIntegerB = UnityEngine.Random.Range(0, Length);
            SwapOnDeckDC(randomIntegerA, randomIntegerB);
        }
       
    }

    private void SwapOnDeckDC(int indexA, int indexB)
    {
        DestinationCards_SO elementA = DestCardsDeck[indexA];
        DestinationCards_SO elementB = DestCardsDeck[indexB];
        DestCardsDeck[indexA] = elementB;
        DestCardsDeck[indexB] = elementA;
    }

    private void DealDC()
    {
        PlayerOne.destinationCardsInHand = new List<DestinationCards_SO>();

        for (int i = 0; i < 3; i++)
        {
            DestinationCards_SO TopcardDC = DestCardsDeck[0];
            DestCardsDeck.Remove(TopcardDC);
            PlayerOne.destinationCardsInHand.Add(TopcardDC);
        }

        for (int i = 0; i < 3; i++)
        {
            DestinationCards_SO TopcardDC = DestCardsDeck[0];
            DestCardsDeck.Remove(TopcardDC);
            PlayerTwo.destinationCardsInHand.Add(TopcardDC);
        }
    }
}


