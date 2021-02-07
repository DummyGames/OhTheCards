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
    bool isMovingObject = false;
    GameObject movingObject;
    int timer = 0;

    void Start()
    {
        deckScript = (Deck) theDeck.GetComponent(typeof(Deck));
    }

    void Update()
    {
        // primary mouse click
        if (Input.GetMouseButton(0))
        {
            // if the player has clicked on the deck and isn't already moving card
            if (DetectClick().Equals(theDeck) && !isMovingObject)
            {
                movingObject = deckScript.GetCard();
                isMovingObject = true;
                MoveObject(movingObject);
            }
            GameObject detectCard;
            if ((detectCard = DetectClick()).CompareTag("Card") && !isMovingObject) 
            {
                movingObject = detectCard;
                isMovingObject = true;
                MoveObject(movingObject);
            }
            
        }

        // right click
        if (Input.GetMouseButton(1)) 
        {
            if (!isMovingObject) { 
                GameObject detectObject = DetectClick();
                if (timer <= 0) 
                {
                    if (detectObject.CompareTag("Card"))
                    {
                        timer = 240;
                        Card cardScript = (Card)detectObject.GetComponent("Card");
                        cardScript.Flip();
                    }
                }
                if (detectObject.CompareTag("Deck"))
                {
                    movingObject = detectObject;
                    isMovingObject = true;
                    MoveObject(movingObject);
                }
            }
        }

        if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1)) 
        {
            isMovingObject = false;
        }

        // if the player is currently moving an object
        if (movingObject != null && isMovingObject)
        {
            MoveObject(movingObject);
        }

        if (timer > 0)
            timer--;
    }

    public void MoveObject(GameObject moveObject) 
    {
        Vector3 pos = MovePosition();
        // just above the game boards Y position
        pos.y = (float) -1.6;
        moveObject.gameObject.transform.position = pos;
    }

    public GameObject DetectClick() 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.collider.gameObject;
        }
        return new GameObject();
    }

    // Gets mouse position
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
