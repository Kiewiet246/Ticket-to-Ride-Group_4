using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;


[Serializable]
public class PlayerHand_UI : MonoBehaviour, IPointerClickHandler
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

    public void OnPointerClick(PointerEventData eventData)
    {
        //throw new NotImplementedException();

        if (gameManager.GoingToBuild == true &&
            AmountOfCards > 0 &&
            gameManager.PickingCardsPanel.activeSelf == true &&
            gameManager.ConfirmButton.activeSelf == false)
        {
            gameManager.CardClicked = this.gameObject.GetComponent<UI_TrainCardsInfo>();
            gameManager.AddCardToSelectedList();
        }
    }
}
