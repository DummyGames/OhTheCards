using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public GameObject theDeck;
    Deck deckScript;
    float yPos;
    float xPos;

    void Start()
    {
        deckScript = (Deck) theDeck.GetComponent(typeof(Deck));
    }

    void Update()
    {
        //primary mouse click
        if (Input.GetMouseButtonDown(0))
        {
            if (DetectDeck())
            {
                //TEMP LOGGING
                Vector3 mousePos = Input.mousePosition;
                xPos = mousePos.x;
                yPos = mousePos.y;
                UnityEngine.Debug.Log("Mouse x: " + xPos + ", Mouse y: " + yPos);
                deckScript.Draw(MovePosition());
            }
        }
    }

    public bool DetectDeck() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.Equals(theDeck))
                return true;
        }
        return false;
    }

    public Vector3 MovePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            return hit.point;
        }
        return new Vector3();
    }
}
