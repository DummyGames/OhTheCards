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
                Vector3 mousePos = Input.mousePosition;
                xPos = mousePos.x;
                yPos = mousePos.y;
                UnityEngine.Debug.Log("Mouse x: " + xPos + ", Mouse Y: " + yPos);
                deckScript.Draw();
            }
        }
    }

    public bool DetectDeck() {
        //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.Equals(theDeck))
                return true;
        }
        return false;
    }
}
