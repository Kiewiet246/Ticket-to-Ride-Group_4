using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;


[Serializable]
public class RoutesScript : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    public DestinationCards_SO.Destinations Destination_1;

    [SerializeField]
    public DestinationCards_SO.Destinations Destination_2;

    [SerializeField]
    public TrainCard_SO.TypesOfTrainCards RouteColour;

    [SerializeField]
    public int RequiredAmountofTrains;

    [SerializeField]
    public GameObject TwinRoad;

    [SerializeField]
    public bool HasTwin;

    public void OnPointerClick(PointerEventData eventData)
    {
        //throw new NotImplementedException();
        Debug.Log(Destination_1);
        Debug.Log(Destination_2);
    }
}