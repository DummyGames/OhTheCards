using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class InputController : MonoBehaviour
{
    float yPos;
    float xPos;

    void Start()
    {
        
    }

    void Update()
    {
        //primary mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            xPos = mousePos.x;
            yPos = mousePos.y;
            UnityEngine.Debug.Log("Mouse x: " + xPos + ", Mouse Y: " + yPos);
        }
    }
}
