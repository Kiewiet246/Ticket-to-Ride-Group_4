using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    private GameObject button;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) == true)
        {
            LeftClick();
        }
    }

    public void LeftClick()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);


        if (hit == false ||
            hit.collider.GetComponent<RoutesScript>() == false)
        {
            gameManager.BuildButton.SetActive(false);
        }

        
    }
}
