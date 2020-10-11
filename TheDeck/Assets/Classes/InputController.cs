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
    bool movingCard = false;
    GameObject card;

    void Start()
    {
        deckScript = (Deck) theDeck.GetComponent(typeof(Deck));
    }

    void Update()
    {

        //primary mouse click
        if (Input.GetMouseButton(0))
        {
            if (DetectDeck() && !movingCard)
            {
                card = deckScript.GetCard();
                movingCard = true;
                //card.gameObject.transform.position = MovePosition();
                MoveCard(card);
            }
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

    public void MoveCard(GameObject card) {
        Vector3 pos = MovePosition();
        pos.y = (float) -1.6;
        card.gameObject.transform.position = pos;
        //card.gameObject.transform.LookAt(MovePosition());
        //card.gameObject.transform.position = Vector3.MoveTowards(card.gameObject.transform.position, MovePosition(), 100f);
        UnityEngine.Debug.DrawLine(card.gameObject.transform.position, MovePosition(), Color.red);
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
