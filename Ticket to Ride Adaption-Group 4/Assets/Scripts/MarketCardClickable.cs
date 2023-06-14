using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

[Serializable]
public class MarketCardClickable : MonoBehaviour, IPointerClickHandler
{
   public GameManager gameManager_Clickable;
    public TrainCard_SO TrainCard_in_Market;
    private int hello;

    public void OnPointerClick(PointerEventData eventData)
    {

        TrainCard_in_Market = this.GetComponent<UI_TrainCardsInfo>().TrainCard;
        TrainCard_in_Market.ClickedInMarket = true;
        gameManager_Clickable.PickUp_MarketCard();
        TrainCard_in_Market.ClickedInMarket = false;
       Destroy(this.gameObject);
    }

}  
