using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

[Serializable]
public class DestinationCard_Clickable : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
     public GameManager gameManager;
    public void OnPointerClick(PointerEventData eventData)
    {
       if (gameManager.CurrentPlayer.HasSelectedDCSetup == false)
        {
            if (gameManager.CurrentPlayer.PickedUpDesCards.Count > 2)
            {
                for (int i = 0; i < gameManager.CurrentPlayer.PickedUpDesCards.Count; i++)
                {
                    if (this.gameObject.GetComponent<DestinationCards_UI>().desCard == gameManager.CurrentPlayer.PickedUpDesCards[i])
                    {
                        DestinationCards_SO removeCard = gameManager.CurrentPlayer.PickedUpDesCards[i];
                        gameManager.CurrentPlayer.PickedUpDesCards.Remove(removeCard);
                        gameManager.cardManager.DestCardsDeck.Add(removeCard);
                        Destroy(this.gameObject);

                    }
                }
            }
        }

        else if (gameManager.CurrentPlayer.HasSelectedDCSetup == true)
        {
            if (gameManager.CurrentPlayer.PickedUpDesCards.Count > 1)
            {
                for (int i = 0; i < gameManager.CurrentPlayer.PickedUpDesCards.Count; i++)
                {
                    if (this.gameObject.GetComponent<DestinationCards_UI>().desCard == gameManager.CurrentPlayer.PickedUpDesCards[i])
                    {
                        DestinationCards_SO removeCard = gameManager.CurrentPlayer.PickedUpDesCards[i];
                        gameManager.CurrentPlayer.PickedUpDesCards.Remove(removeCard);
                        gameManager.cardManager.DestCardsDeck.Add(removeCard);
                        Destroy(this.gameObject);

                    }
                }
            }
        }

           
        
    }
}
