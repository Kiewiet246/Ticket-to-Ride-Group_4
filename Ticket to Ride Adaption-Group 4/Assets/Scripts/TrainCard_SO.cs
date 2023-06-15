using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


// Scriptable Object Script for traincards.


[CreateAssetMenu(menuName = "ScriptableObject/TrainCards")]
public class TrainCard_SO : ScriptableObject
{
 
    [SerializeField]
    public string CardName;
  
    [SerializeField]
    public Sprite sprite;

    [SerializeField]
    public TypesOfTrainCards trainCardsType;

    public enum TypesOfTrainCards
    {
        Box,
        Caboose,
        Passenger,
        Tanker,
        Reefer,
        Freight,
        Hopper,
        Coal,
        Locomotives
    }
}
