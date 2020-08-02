﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{   //the set of cards in a deck 
    public ArrayList<Card> listOfCards;
    public GameObject theCard;
    private GameObject newCard;
    private Random random = new Random();
    // Start is called before the first frame update
    void Start()
    {
        list = new ArrayList<Card>();
        for (int i = 0; i < 4; i++) {
            for (int j = 1; j <= 13; j++) {
                Card card = new Card(i, j);
                list.Add(card);
            }
        }
        shuffle();
        //need to figure out how to instantiate a card based on the Card objects we've created
        foreach(Card c in listOfCards) {
            newCard = Instantiate(theCard);
            newCard.SetActive(false);
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

    private void initDeck() {
            
    }

    public void shuffle() {
        ArrayList<Card> array = new ArrayList<Card>();
        int count = listOfCards.Count;
        for (int i = 0; i < count; i++) {
            int randomNum = random.Next(0, listOfCards.Count - 1);
            array.Add(listOfCards.RemoveAt(randomNum));
        }
        listOfCards = array;
    }


}
