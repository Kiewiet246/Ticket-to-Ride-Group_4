using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;




[Serializable]
public class CheckingDestinationCards : MonoBehaviour
{
    [SerializeField]
    public PlayerHand TestPlayer;

    [SerializeField]
    public DestinationCards_SO DestCard;

    [SerializeField]
    public List<DestinationCards_SO> ListDestCards;

    [SerializeField]
    public  List<GameObject> Followroad;

    [SerializeField]
    GameManager gameManager;


    private GameObject checkFromThis;


    private bool FoundARoad;
    private int PositionInRoadsbuiltList;

    [SerializeField]
    private List<GameObject> storeRoad;

    // Start is called before the first frame update
    void Start()
    {
        foreach (DestinationCards_SO destinationCards in ListDestCards)
        {
            DestCard = destinationCards;
            Debug.Log(DestCard);
            CheckDestCard();
        }


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayerDestCards()
    {
        foreach (PlayerHand playerhand in gameManager.players)
        {
            foreach(DestinationCards_SO DesCards in playerhand.destinationCardsInHand)
            {
                DestCard = DesCards;
                CheckDestCard();
            }
        }
    }
    
    
    
    
    public void CheckDestCard()
    {
        foreach (GameObject road in TestPlayer.roadsBuilt)
        {
          if (road.GetComponent<RoutesScript>().Destination_1 == DestCard.destinationA ||
               road.GetComponent<RoutesScript>().Destination_2 == DestCard.destinationA)
            {
                PositionInRoadsbuiltList = TestPlayer.roadsBuilt.IndexOf(road);
               TestPlayer.roadsBuilt.Remove(road);
                Followroad.Add(road);
                checkFromThis = road;
                ContinueCheck();
            }
        }
    }


    public void ContinueCheck()
    {


        foreach (GameObject road in TestPlayer.roadsBuilt)
        {
            if (road.gameObject.GetComponent<RoutesScript>().Destination_1 == checkFromThis.gameObject.GetComponent<RoutesScript>().Destination_1 ||
                road.gameObject.GetComponent<RoutesScript>().Destination_1 == checkFromThis.gameObject.GetComponent<RoutesScript>().Destination_2 ||
                road.gameObject.GetComponent<RoutesScript>().Destination_2 == checkFromThis.gameObject.GetComponent<RoutesScript>().Destination_1 ||
                road.gameObject.GetComponent<RoutesScript>().Destination_2 == checkFromThis.gameObject.GetComponent<RoutesScript>().Destination_2)
            {

                FoundARoad = true;

                TestPlayer.roadsBuilt.Remove(road);
                Followroad.Add(road);
               

                if (road.gameObject.GetComponent<RoutesScript>().Destination_1 == DestCard.destinationB ||
                    road.gameObject.GetComponent<RoutesScript>().Destination_2 == DestCard.destinationB)
                {
                    TestPlayer.PlayerScore += DestCard.PointValue;

                    foreach (GameObject Placeroadback in Followroad)
                    {
                       
                       
                       // Followroad.Remove(Placeroadback);
                        TestPlayer.roadsBuilt.Add(Placeroadback);
                    }

                    for (int i = 0; i < Followroad.Count; i+=0)
                    {
                        
                        
                        Followroad.Remove(Followroad[i]);
                    }
                }






                else
                {
                    FoundARoad = false;
                   // Debug.Log("hier");
                    checkFromThis = road;
                    ContinueCheck();
                }

            }

            //Debug.Log("help");
        }

        if (FoundARoad == false)
        {
           
            
            GameObject keeptrack = checkFromThis;
            Followroad.Remove(keeptrack);
            //TestPlayer.roadsBuilt.Add(keeptrack);
            storeRoad.Add(keeptrack);
           // Debug.Log(Followroad.Count);
            checkFromThis = Followroad[Followroad.Count - 1];
            ContinueCheck();
        }

        foreach (GameObject Placeroadback in Followroad)
        {


            // Followroad.Remove(Placeroadback);
            TestPlayer.roadsBuilt.Add(Placeroadback);
        }

        for (int i = 0; i < Followroad.Count; i += 0)
        {


            Followroad.Remove(Followroad[i]);
        }

        foreach (GameObject Placeroadback in storeRoad)
        {


            // Followroad.Remove(Placeroadback);
            TestPlayer.roadsBuilt.Add(Placeroadback);
        }

        for (int i = 0; i < storeRoad.Count; i += 0)
        {


            storeRoad.Remove(storeRoad[i]);
        }
    }

        
           
}
