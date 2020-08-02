using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{   //the set of cards in a deck 
    public Stack StackOfCards;
    public GameObject theCard;
    private GameObject newCard;
    // Start is called before the first frame update
    void Start()
    {
        StackOfCards = new Stack();
         for (int i = 0; i < 4; i++) {
             for (int j = 2; j < 15; j++)
            {
                Debug.Log(j);
                newCard = Instantiate(theCard);
                newCard.SetActive(false);
                StackOfCards.Push(newCard);
             }
         }
    }


}
