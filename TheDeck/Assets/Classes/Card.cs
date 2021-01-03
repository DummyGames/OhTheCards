using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public enum Suit 
    {
        Spades,
        Clubs,
        Diamonds,
        Hearts
    }

    public enum Rank 
    {
        Ace = 1,
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

    public Suit suit;
    public Rank rank;
    // can other player see the face of the card?
    private bool flippedOver = false;

    public void SetSuit(int suit)
    {
        this.suit = (Suit)suit;
    }

    public void SetRank(int rank)
    {
        this.rank = (Rank)rank;
    }

    public int GetSuit() 
    {
        return (int) suit;
    }

    public int GetRank() 
    {
        return (int) rank;
    }

    public bool IsFlipped() 
    {
        return flippedOver;
    }

    public void Flip() 
    {
        flippedOver = flippedOver ? false : true;
    }

    //Suits do not matter currently
    public bool Compare(Card c) 
    {
        int cardRank = c.GetRank();
        return (int) rank >= cardRank; 
    }
}
