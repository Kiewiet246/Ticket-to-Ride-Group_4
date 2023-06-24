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

    [SerializeField]
    private Material[] material;

    private Renderer Rend;


    public void OnPointerClick(PointerEventData eventData)
    {
        //throw new NotImplementedException();
        Debug.Log(Destination_1);
        Debug.Log(Destination_2);
    }


    public void Start()
    {
       for (int i= 0; i < this.transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Rend = child.gameObject.GetComponent<Renderer>();
            Rend.enabled = true;
            Rend.sharedMaterial = material[(int)RouteColour];
            Debug.Log((int)RouteColour);
        }


        
    }
}