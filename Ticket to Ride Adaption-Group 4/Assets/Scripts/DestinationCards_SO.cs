using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


// Scriptable Object script that makes the destination cards. I used an enum to apply the destinations to each of the cards.


[Serializable]
[CreateAssetMenu(menuName = "ScriptableObject/DestinationCards")]
public class DestinationCards_SO : ScriptableObject
{
    [SerializeField]
    public Destinations destinationA;

    [SerializeField]
    public Destinations destinationB;

    [SerializeField]
    public int PointValue;


   public enum Destinations
    {
        Atlanta,
        Boston,
        Calgary,
        Chicago,
        Charleston,
        Dallas,
        Denver,
        Duluth,
        El_Paso,
        Helena,
        Houston,
        Kansas_City,
        Las_Vegas,
        Little_Rock,
        Los_Angeles,
        Miami,
        Montréal,
        Nashville,
        New_Orleans,
        New_York,
        Oklahoma_City,
        Omaha,
        Phoenix,
        Pittsburgh,
        Portland,
        Raleigh,
        Saint_Louis,
        Salt_Lake_City,
        San_Francisco,
        Santa_Fe,
        Sault_St_Marie,
        Seattle,
        Toronto,
        Vancouver,
        Washington,
        Winnipeg
    }
}
