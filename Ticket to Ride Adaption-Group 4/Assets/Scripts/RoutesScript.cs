using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



[Serializable]
public class RoutesScript : MonoBehaviour
{
   [SerializeField]
    public DestinationCards_SO.Destinations Destination_1;

    [SerializeField]
    public DestinationCards_SO.Destinations Destination_2;

    [SerializeField]
    public TrainCard_SO.TypesOfTrainCards RouteCoulour;
}
