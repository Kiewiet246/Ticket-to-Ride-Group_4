using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


// Class that is used to make the player hands. Includes train cards, Destination Cards and amount of wooden trains.

[Serializable]
public class PlayerHand
{
    [SerializeField]
    public List<TrainCard_SO> CardsInHand;
    [SerializeField]
    public List<DestinationCards_SO> destinationCardsInHand;

    public int WoodenTrains = 45;
}
