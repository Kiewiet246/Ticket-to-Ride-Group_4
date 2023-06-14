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
    public Destinations destinationsB;

    [SerializeField]
    public int PointValue;


   public enum Destinations
    {
        Atlanta,
        Boston,
        Calgary,
        Chicago,
        Dallas,
        Denver,
        Duluth,
        El_Paso,
        Helena,
        Houston,
        Kansas_City,
        Little_Rock,
        Los_Angeles,
        Miami,
        Montréal,
        Nashville,
        New_Orleans,
        New_York,
        Oklahoma_City,
        Phoenix,
        Pittsburgh,
        Portland,
        Salt_Lake_City,
        San_Francisco,
        Santa_Fe,
        Sault_St_Marie,
        Seattle,
        Toronto,
        Vancouver,
        Winnipeg
    }
}
