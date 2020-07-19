using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    private String suit;
    private String rank;
    //can other player see the face of the card?
    private bool flippedOver = false;

    public Card(String suit, String rank) {
        switch (suit) {
            case "Clubs":
            case "Diamonds":
            case "Hearts":
            case "Spades":
                this.suit = suit;
                break;

            default:
                throw new ArgumentException("Illegal value for suit: '" + suit + "'");
                break;
        }

        switch (rank) {
            case "One":
            case "Two":
            case "Three":
            case "Four":
            case "Five":
            case "Six":
            case "Seven":
            case "Eight":
            case "Nine":
            case "Ten":
            case "King":
            case "Queen":
            case "Ace":
            case "Jack":
                this.rank = rank;
                break;

            default:
                throw new ArgumentException("Illegal value for rank: '" + rank + "'");
                break;

        }
    }

    public String getSuit() {
        return suit;
    }

    public String getRank() {
        return rank;
    }

    public bool isFlipped() {
        return flippedOver;
    }

    public void flip() {
        flippedOver = flippedOver ? false : true;
    }

    //TODO: do this please!
    public bool Compare(Card c) {
            
    }

    
}
