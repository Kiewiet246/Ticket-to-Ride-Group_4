using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;



// This script is used to make the Market cards interactable and on click be placed in side the player's hand

[Serializable]
public class MarketCardClickable : MonoBehaviour, IPointerClickHandler
{
   public GameManager gameManager_Clickable;
   

    public void OnPointerClick(PointerEventData eventData)
    {
       if (gameManager_Clickable.CurrentPlayer.ActionTaken == false &&
            this.gameObject.GetComponent<UI_TrainCardsInfo>().CanPickUpAgain == true) // Checks if current player can pick up again
        {
            Debug.Log("Start");
            Debug.Log(this.gameObject.GetComponent<UI_TrainCardsInfo>().TrainCard.CardName + " was clicked");
            gameManager_Clickable.PositionInHierarchy = this.transform.GetSiblingIndex();   //Gets position of the child in Hierachy under OpenMarket parent
            gameManager_Clickable.CardClicked = this.gameObject.GetComponent<UI_TrainCardsInfo>(); //Gets the information of the UI_TrainCard clicked.
            this.gameObject.transform.parent = null;
         
            
            gameManager_Clickable.PickUp_MarketCard(); // Calls the PickUp_MarketCard method which moves the card from OpenMarket list to TrainCardsInHand-list of current player.



           Destroy(this.gameObject); // Destroys the card that was clicked.
        }
        
        

    }

}  
