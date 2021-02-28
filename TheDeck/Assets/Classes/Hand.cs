using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{

    public GameObject handArea;
    public List<GameObject> cards;
    public float cardGap;
    private int cardsAdded;
    private Vector3 middle;

    private void Start()
    {
        cardsAdded = 0;
        cards = new List<GameObject>();
        middle = handArea.gameObject.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Card"))
        {
            GameObject card = other.gameObject;
            cards.Add(card);
            cardsAdded++;
            FitAddedCard();
            card.transform.rotation = Quaternion.Euler(260, 0, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Card"))
        {
            GameObject card = other.gameObject;
            cards.Remove(card);
            cardsAdded--;
            FitRemovedCard();
            card.transform.rotation = Quaternion.Euler(90, 0, 0);
        }
    }

    private void FitAddedCard() 
    {
        // if 1 card, direct middle
        if (cardsAdded == 1)
        {
            cards[0].gameObject.transform.position = middle;
        }
        else 
        {

            Vector3 cardVector = cards[0].gameObject.GetComponent<Collider>().bounds.size;
            float cardWidth = cardVector.x;
            Debug.Log("x: " + cardVector.x);
            Debug.Log("y: " + cardVector.y);
            Debug.Log("z: " + cardVector.z);
            float totalSpace = cardWidth * cardsAdded + cardGap * cardsAdded;
            float halfSpace = totalSpace / 2;
            Debug.Log("total space: " + totalSpace);
            for (int i = 0; i < cards.Count; i++) 
            {
                float newX = middle.x - halfSpace + (totalSpace - cardWidth);
                // take cards total distance all together, base off of center, then set individual positions
                Vector3 newPosition = new Vector3(newX, middle.y, middle.z);
                cards[i].transform.position = newPosition;
                totalSpace -= cardWidth;
                


            } 
        }
        // more than 1 card, shift all cards to left and add new card
    }

    private void FitRemovedCard() 
    {
        // if 0 card, don't care
        if (cardsAdded != 0) 
        {
        
        }
        // if more than 1 move all to left
    }
}
