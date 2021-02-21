using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Card"))
        {
            GameObject card = other.gameObject;
            card.transform.rotation = Quaternion.Euler(260, 0, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Card"))
        {
            GameObject card = other.gameObject;
            card.transform.rotation = Quaternion.Euler(90, 0, 0);
        }
    }
}
