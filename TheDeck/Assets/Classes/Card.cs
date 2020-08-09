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

    private Suit suit;
    private Rank rank;
    //can other player see the face of the card?
    private bool flippedOver = false;

    public Card(int suit, int rank) {
        //switch (suit) {
        //    case "Clubs":
        //    case "Diamonds":
        //    case "Hearts":
        //    case "Spades":
        //        this.suit = suit;
        //        break;

        //    default:
        //        throw new ArgumentException("Illegal value for suit: '" + suit + "'");
        //        break;
        //}
        this.suit = (Suit) suit;
        this.rank = (Rank) rank;
    }

    public int getSuit() {
        return (int) suit;
    }

    public int getRank() {
        return (int) rank;
    }

    public bool isFlipped() {
        return flippedOver;
    }

    public void flip() {
        flippedOver = flippedOver ? false : true;
    }

    //Suits do not matter currently
    public bool Compare(Card c) {
        int cardRank = c.getRank();
        return (int) rank >= cardRank; 
    }

    
}
