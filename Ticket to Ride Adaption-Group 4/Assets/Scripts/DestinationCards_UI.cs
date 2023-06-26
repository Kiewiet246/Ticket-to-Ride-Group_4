using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DestinationCards_UI : MonoBehaviour
{
    [SerializeField]public DestinationCards_SO desCard;
    [SerializeField] private Text DestinationA;
    [SerializeField] private Text DestinationB;
    [SerializeField] private Text ScoreValue;

    private void Update()
    {
        DestinationA.text = desCard.destinationA.ToString();
        DestinationB.text = desCard.destinationB.ToString();
        ScoreValue.text = desCard.PointValue.ToString();
    }

}
