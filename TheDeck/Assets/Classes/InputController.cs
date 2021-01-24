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
    // boolean to detect is player is currently moving card
    bool movingCard = false;
    GameObject card;

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
            if (DetectClick().Equals(theDeck) && !movingCard)
            {
                card = deckScript.GetCard();
                movingCard = true;
                MoveCard(card);
            }
            GameObject detectCard;
            if ((detectCard = DetectClick()).CompareTag("Card") && !movingCard) 
            {
                card = detectCard;
                movingCard = true;
                MoveCard(card);
            }
            // if the player is currently moving a card
            if (card != null && movingCard)
            {
                MoveCard(card);
            }
        }
        else 
        {
            movingCard = false;
        }
    }

    public void MoveCard(GameObject card) 
    {
        Vector3 pos = MovePosition();
        // just above the game boards Y position
        pos.y = (float) -1.6;
        card.gameObject.transform.position = pos;
    }

    // TODO: make this return the object that was hit instead of being
    // just the deck object
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
