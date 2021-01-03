using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{   
    private List<GameObject> listOfCardObjects;
    public GameObject cardGameObject;
    private System.Random random = new System.Random();

    void Start()
    {
        // create a full deck at start of game and shuffle the cards
        listOfCardObjects = new List<GameObject>();
        for (int i = 0; i < 4; i++) {
            for (int j = 1; j <= 13; j++) {
                GameObject newCard = Instantiate(cardGameObject);
                Card card = newCard.GetComponent<Card>();
                card.SetSuit(i);
                card.SetRank(j);
                newCard.SetActive(false);
                listOfCardObjects.Add(newCard);
            }
        }
        Shuffle();
    }

    public GameObject GetCard()
    {
        if (listOfCardObjects.Count != 0)
        {
            GameObject poppedCard = listOfCardObjects[0];
            listOfCardObjects.RemoveAt(0);
            poppedCard.SetActive(true);
            return poppedCard;
        }
        return null;
    }

    public void Shuffle() 
    {
        List<GameObject> array = new List<GameObject>();
        int count = listOfCardObjects.Count;
        for (int i = 0; i < count; i++) {
            int randomNum = random.Next(0, listOfCardObjects.Count - 1);
            array.Add(listOfCardObjects[randomNum]);
            listOfCardObjects.RemoveAt(randomNum);
        }
        listOfCardObjects = array;
    }
}
