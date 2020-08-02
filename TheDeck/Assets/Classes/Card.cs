using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public enum Suit {
        Spades, 
        Clubs,
        Diamonds,
        Hearts
    }

    public enum Rank {
        Ace=1, 
        Two,  
        Three,
        Four, 
        Five, 
        Six,  
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    private String suit;
    private String rank;
    //can other player see the face of the card?
    private bool flippedOver = false;

    public Card(String suit, Rank rank) {
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

        this.rank = rank;
    }

    public Suit getSuit() {
        return suit;
    }

    public Rank getRank() {
        return rank;
    }

    public bool isFlipped() {
        return flippedOver;
    }

    public void flip() {
        flippedOver = flippedOver ? false : true;
    }

    //Suits do not matter currently
    public bool Compare(Card c) {
        Rank cardRank = c.getRank;
        return rank >= cardRank ? true : false; 
    }

    
}
