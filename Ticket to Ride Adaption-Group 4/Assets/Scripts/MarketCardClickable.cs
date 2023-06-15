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
       // Destroy(this.gameObject);
  

        
        
      
        gameManager_Clickable.PositionInHierarchy = this.transform.GetSiblingIndex();
        gameManager_Clickable.cardsInMarket = this.gameObject.GetComponent<UI_TrainCardsInfo>();
       
        gameManager_Clickable.PickUp_MarketCard();
        Destroy(this.gameObject);

    }

}  
