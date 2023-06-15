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
    private TrainCard_SO[] TrainCards_So;
    [SerializeField]
    private TrainCard_SO LocomotiveCard;
   
    
    [SerializeField]
    public List<TrainCard_SO> DeckofTrainCards;
    [SerializeField]
    List<TrainCard_SO> Discardpile_TrainCards;


    [SerializeField]
    public List<TrainCard_SO> openMarket;

    private int CountLoco =0;

    [SerializeField]
    private Transform OMparent;
    [SerializeField]
    private GameObject Prefab_TC_UI;
    private TrainCard_SO TCFORUi;

    [SerializeField]
    public PlayerHand PlayerOne;
    [SerializeField]
    public PlayerHand PlayerTwo;

    [SerializeField]
    public List<DestinationCards_SO> DestCardsDeck;

    private GameObject Test;

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
        DeckofTrainCards = new List<TrainCard_SO>();
      
        foreach (TrainCard_SO TrainCard in TrainCards_So)
        {
           for (int i = 0; i < 12; i++)
            {
                DeckofTrainCards.Add(TrainCard);
                //TrainCard.ClickedInMarket = false;
            }
        }

        for (int i = 0; i < 14; i++)
        {
            DeckofTrainCards.Add(LocomotiveCard);
           // LocomotiveCard.ClickedInMarket = false;
        }

      
    }

    public void ShuffleTrainCards()
    {
        int Length = DeckofTrainCards.Count;
        int HalfLength = DeckofTrainCards.Count / 2;
        for (int i = 0; i < HalfLength; i++)
        {
            int randomIntegerA = UnityEngine.Random.Range(0, Length);
            int randomIntegerB = UnityEngine.Random.Range(0, Length);
            SwapOnDeckTC(randomIntegerA, randomIntegerB);
        }
    }

    private void SwapOnDeckTC(int indexA, int indexB)
    {
        TrainCard_SO elementA = DeckofTrainCards[indexA];
        TrainCard_SO elementB = DeckofTrainCards[indexB];
        DeckofTrainCards[indexA] = elementB;
        DeckofTrainCards[indexB] = elementA;
    }


    private void DealCardsTrainCards()
    {
        PlayerOne.TrainCardsInHand = new List<TrainCard_SO>();

        for (int i = 0; i < 4; i++)
        {
            TrainCard_SO topCard = DeckofTrainCards[0];
            DeckofTrainCards.Remove(topCard);
            PlayerOne.TrainCardsInHand.Add(topCard);
        }

        PlayerTwo.TrainCardsInHand = new List<TrainCard_SO>();

        for (int i = 0; i < 4; i++)
        {
            TrainCard_SO topCard = DeckofTrainCards[0];
            DeckofTrainCards.Remove(topCard);
            PlayerTwo.TrainCardsInHand.Add(topCard);
        }
    }
    
    
    
    
    
    public void OpenMarket()
    {
        openMarket = new List<TrainCard_SO>();
        
        for (int i =0; i< 5; i++)
        {
            TrainCard_SO topCard = DeckofTrainCards[0];
            DeckofTrainCards.Remove(topCard);
            openMarket.Add(topCard);
            Prefab_TC_UI.GetComponent<UI_TrainCardsInfo>().TrainCard = topCard;
            Test = Prefab_TC_UI;
            Test = Instantiate(Prefab_TC_UI, OMparent);
            Test.AddComponent<MarketCardClickable>();
            Test.GetComponent<MarketCardClickable>().gameManager_Clickable = gameManager_CardM;
            //Test.GetComponent<UI_TrainCardsInfo>().CanPickUpAgain = true;

            // Prefab_TC_UI.GetComponent<UI_TrainCardsInfo>().TrainCard = topCard;
        }
       
        CheckingMarket();
    }


    public void RefillMarket()
    {
        
        
        
        TrainCard_SO topCard = DeckofTrainCards[0];
        DeckofTrainCards.Remove(topCard);
        openMarket.Insert(gameManager_CardM.PositionInHierarchy, topCard);
        

        Prefab_TC_UI.GetComponent<UI_TrainCardsInfo>().TrainCard = topCard;
        Test = Prefab_TC_UI;
        Test = Instantiate(Prefab_TC_UI, OMparent);
        Test.AddComponent<MarketCardClickable>();
        Test.GetComponent<MarketCardClickable>().gameManager_Clickable = gameManager_CardM;
        // Test.gameObject.transform.SetAsLastSibling();

        Test.gameObject.transform.SetSiblingIndex(gameManager_CardM.PositionInHierarchy);

        if (topCard.trainCardsType == TrainCard_SO.TypesOfTrainCards.Locomotives)
        {
            Test.GetComponent<UI_TrainCardsInfo>().CanPickUpAgain = false;
        }
         
        
        else if (topCard.trainCardsType != TrainCard_SO.TypesOfTrainCards.Locomotives)
        {
            for (int i = 0; i < OMparent.childCount; i++)
            {
               Transform CheckLoco = OMparent.GetChild(i);

              if (CheckLoco.GetComponent<UI_TrainCardsInfo>().TrainCard.trainCardsType == TrainCard_SO.TypesOfTrainCards.Locomotives)
                {
                    CheckLoco.GetComponent<UI_TrainCardsInfo>().CanPickUpAgain = false;
                }
            }
        }

        CheckingMarket();
    }

    

  
    
    
    public void CheckingMarket()
    {
        foreach (TrainCard_SO openCard in openMarket)
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
            TrainCard_SO FirstCard = openMarket[0];
            openMarket.Remove(FirstCard);
            Discardpile_TrainCards.Add(FirstCard);
            
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


