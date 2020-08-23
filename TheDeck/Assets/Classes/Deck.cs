using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{   //the set of cards in a deck 
    public List<Card> listOfCards;
    private List<GameObject> listOfObjects;
    public GameObject theCard;
    private GameObject newCard;
    private System.Random random = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        listOfCards = new List<Card>();
        for (int i = 0; i < 4; i++) {
            for (int j = 1; j <= 13; j++) {
                Card card = new Card(i, j);
                listOfCards.Add(card);
            }
        }
        shuffle();
        //need to figure out how to instantiate a card based on the Card objects we've created
        listOfObjects = new List<GameObject>();
        foreach(Card c in listOfCards) {
            newCard = Instantiate(theCard);
            newCard.SetActive(false);
            listOfObjects.Add(newCard);
        }
        //StackOfCards = new Stack();
        // for (int i = 0; i < 4; i++) {
        //     for (int j = 2; j < 15; j++)
        //    {
        //        Debug.Log(j);
        //       
        //        StackOfCards.Push(newCard);
        //     }
        // }
    }

    public void Draw()
    {
        if (listOfCards.Count != 0)
        {
            Card poppedCard = listOfCards[0];
            listOfCards.RemoveAt(0);
            GameObject card = listOfObjects[0];
            card.SetActive(true);
        }
    }


    public void shuffle() {
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
