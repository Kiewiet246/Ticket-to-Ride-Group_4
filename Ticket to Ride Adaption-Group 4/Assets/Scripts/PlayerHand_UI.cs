using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


[Serializable]
public class PlayerHand_UI : MonoBehaviour
{
    [SerializeField]
    private Text TextofAmoount;

    [SerializeField]
    private int AmountOfCards;

   [SerializeField]
    GameManager gameManager;

   private TrainCard_SO trainCard;

    // Start is called before the first frame update
    void Start()
    {
        trainCard = this.gameObject.transform.GetComponent<UI_TrainCardsInfo>().TrainCard;

        Debug.Log(trainCard);
    }

    // Update is called once per frame
    void Update()
    {
        TextofAmoount.text = AmountOfCards.ToString();

       

        

        if (gameManager.CurrentPlayer.TrainCardsInHand.Count != 0)
        {
            CountAmountOfTrainCards();
        }
    }


   public void CountAmountOfTrainCards()
    {

        AmountOfCards = 0;
        
       
        
        for (int i = 0; i < gameManager.CurrentPlayer.TrainCardsInHand.Count; i++)
        {
            if (gameManager.CurrentPlayer.TrainCardsInHand[i] == trainCard)
            {
                AmountOfCards++;
            }
        }
       
        
        //if (AmountOfCards == 0)
     //   {
        //    this.gameObject.SetActive(false);
        //}

    }
}
