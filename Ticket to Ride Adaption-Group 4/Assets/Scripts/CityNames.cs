using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CityNames : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    DestinationCards_SO.Destinations City;

    [SerializeField]
    private Text Cityname;


    public void OnPointerClick(PointerEventData eventData)
    {
        // throw new NotImplementedException();
        Debug.Log(City);
    }

    public void Start()
    {
        Cityname.text = City.ToString();
    }
}
