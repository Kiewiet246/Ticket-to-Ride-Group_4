using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class CityNames : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    DestinationCards_SO.Destinations City;


    public void OnPointerClick(PointerEventData eventData)
    {
        // throw new NotImplementedException();
        Debug.Log(City);
    }
}
