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
    List<TrainCard_SO> DeckofTrainCards;
    [SerializeField]
    List<TrainCard_SO> Discardpile_TrainCards;


    [SerializeField]
    List<TrainCard_SO> openMarket;

    private int CountLoco =0;

    [SerializeField]
    private Transform OMparent;
    [SerializeField]
    private GameObject Prefab_TC_UI;
    private TrainCard_SO TCFORUi;

    [SerializeField]
    PlayerHand PlayerOne;
    [SerializeField]
    PlayerHand PlayerTwo;

    [SerializeField]
    List<DestinationCards_SO> DestCardsDeck;
    


    private void Awake()
    {
        CreateDeck();
        ShuffleTrainCards();
        DealCardsTrainCards();
        OpenMarket();

        ShuffleDestCards();
        DealDC();
       

    }

    public void CreateDeck()
    {
        DeckofTrainCards = new List<TrainCard_SO>();
      
        foreach (TrainCard_SO test in TrainCards_So)
        {
           for (int i = 0; i < 12; i++)
            {
                DeckofTrainCards.Add(test);
            }
        }

        for (int i = 0; i < 14; i++)
        {
            DeckofTrainCards.Add(LocomotiveCard);
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
        PlayerOne.CardsInHand = new List<TrainCard_SO>();

        for (int i = 0; i < 4; i++)
        {
            TrainCard_SO topCard = DeckofTrainCards[0];
            DeckofTrainCards.Remove(topCard);
            PlayerOne.CardsInHand.Add(topCard);
        }

        PlayerTwo.CardsInHand = new List<TrainCard_SO>();

        for (int i = 0; i < 4; i++)
        {
            TrainCard_SO topCard = DeckofTrainCards[0];
            DeckofTrainCards.Remove(topCard);
            PlayerTwo.CardsInHand.Add(topCard);
        }
    }
    
    
    
    
    
    public void OpenMarket()
    {
        openMarket = new List<TrainCard_SO>();
        
        for (int i = 0; i < 5; i++)
        {
            TrainCard_SO topCard = DeckofTrainCards[0];
            DeckofTrainCards.Remove(topCard);
            openMarket.Add(topCard);
            Debug.Log("Hier");
            Prefab_TC_UI.GetComponent<UI_TrainCardsInfo>().TC_Ui = topCard;

          
           Instantiate(Prefab_TC_UI, OMparent);
          

        }

        CheckingMarket();
    }

  
    
    
    public void CheckingMarket()
    {
        foreach (TrainCard_SO openCard in openMarket)
        {
           if (openCard == LocomotiveCard)
            {
                Debug.Log("jip");
                CountLoco += 1;
                Debug.Log(CountLoco + "Counting");
                
            }

           
        }

        if (CountLoco >= 3)
        {
            ClearingOpenMarket();
            
            CountLoco = 0;
           
            ShuffleTrainCards();
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


