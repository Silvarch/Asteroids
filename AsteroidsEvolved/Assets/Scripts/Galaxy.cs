/*******************************************************************************************************************************************************************
Program:Asteroids Evolved
Authors: Derrick Grant, Justin Perkins, Kyle Shaw, Logan Larocque
Date: April 17,2022
Class: Galaxy
Purpose: visual graphic to immerse player
Notes: Simple code that adds movement to a background object
********************************************************************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Written by DG
public class Galaxy : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        RotateLeft();
    }

    void RotateLeft()
    {
        transform.Rotate(Vector3.back);
    }

}
// Written by DG
