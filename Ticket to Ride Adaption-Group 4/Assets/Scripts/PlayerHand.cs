using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


// Class that is used to make the player hands. Includes train cards, Destination Cards and amount of wooden trains.

[Serializable]
public class PlayerHand
{
    [SerializeField]
    public List<TrainCard_SO> TrainCardsInHand;  // List of TrainCards in the player's hand.
    [SerializeField]
    public List<DestinationCards_SO> destinationCardsInHand; // List of Destination Cards in player's hand.

    public int WoodenTrains = 45; //Wooden trains of player. If a route is build this should be subtracted.


    public bool ActionTaken; // Checks if the player has done the an action.
    public bool BusyWithAction; // Used with the pick up train Cards action so players can't pick up a card and do something else.

    [SerializeField]
    public List<GameObject> roadsBuilt; // List of all the roads the player has built 


    [SerializeField]
    public int PlayerScore = 0; // The player's score
}
