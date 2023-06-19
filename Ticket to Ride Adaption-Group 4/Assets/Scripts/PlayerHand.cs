using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


// Class that is used to make the player hands. Includes train cards, Destination Cards and amount of wooden trains.

[Serializable]
public class PlayerHand
{
    [SerializeField]
    public List<TrainCard_SO> TrainCardsInHand;
    [SerializeField]
    public List<DestinationCards_SO> destinationCardsInHand;

    public int WoodenTrains = 45;

    public bool ActionTaken;

    [SerializeField]
    public List<GameObject> roadsBuilt;


    [SerializeField]
    public int PlayerScore = 0;
}
