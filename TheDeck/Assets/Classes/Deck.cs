using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{   
    public List<Card> listOfCards;
    private List<GameObject> listOfCardObjects;
    public GameObject cardGameObject;
    private GameObject newCard;
    private int nextCard;
    private System.Random random = new System.Random();

    void Start()
    {
        // create a full deck at start of game and shuffle the cards
        listOfCards = new List<Card>();
        for (int i = 0; i < 4; i++) {
            for (int j = 1; j <= 13; j++) {
                Card card = new Card(i, j);
                listOfCards.Add(card);
            }
        }
        Shuffle();

        // create GameObjects for each Card object
        listOfCardObjects = new List<GameObject>();
        foreach (Card c in listOfCards) {
            newCard = Instantiate(cardGameObject);
            //TODO: remove this foreach loop, instantiate all
            //GameObjects in nested for loop above and refactor
            //Shuffle() to shuffle the list of Card GameObjects
            //newCard.GetComponent<Card>();
            newCard.SetActive(false);
            listOfCardObjects.Add(newCard);
        }
        nextCard = 0;
    }

    public GameObject GetCard()
    {
        if (listOfCards.Count != 0)
        {
            Card poppedCard = listOfCards[0];
            listOfCards.RemoveAt(0);
            GameObject card = listOfCardObjects[nextCard++];
            card.SetActive(true);
            return card.gameObject;
        }
        return null;
    }


    public void Shuffle() {
        List<Card> array = new List<Card>();
        int count = listOfCards.Count;
        for (int i = 0; i < count; i++) {
            int randomNum = random.Next(0, listOfCards.Count - 1);
            array.Add(listOfCards[randomNum]);
            listOfCards.RemoveAt(randomNum);
        }
        listOfCards = array;
    }


}
