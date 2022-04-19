/*******************************************************************************************************************************************************************
Program:Asteroids Evolved
Authors: Derrick Grant, Justin Perkins, Kyle Shaw, Logan Larocque
Date: April 17,2022
Class: AsteroidMovement
Purpose: Controls movment of the asteroid gameObject to which this script is attatched to.
Notes: Straight forward script transforme.translate is called to have the asteroid move downward at a constant speed. Object is destroyed on collision with specific gameObjects
********************************************************************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : SpawnManager
{
    /* Written by LL */

    // Update is called once per frame, movement for this object is set to straight down
    void Update()
    {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    // Objects are destroyed upon collision with specific Objects
    void OnTriggerEnter2D(Collider2D StruckObject)
    {
        if (StruckObject.tag != "Asteroid" && StruckObject.tag != "Bounds" && StruckObject.tag != "HugeAsteroid" && StruckObject.tag != "Trail")
        {
            Destroy(gameObject);
        }
    }

    //Objects are destroyed after leaving the screen
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
