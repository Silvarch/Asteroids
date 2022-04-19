/*******************************************************************************************************************************************************************
Program:Asteroids Evolved
Authors: Derrick Grant, Justin Perkins, Kyle Shaw, Logan Larocque
Date: April 17,2022
Class: HugeAsteroidMovement
Purpose: Controls movment of the asteroid gameObject to which this script is attatched to.
Notes: Straight forward script transforme.translate is called to have the asteroid move downward at a constant speed. Object is destroyed on collision with specific gameObjects
       Additional rules exist to split the asteroid into two smaller ones upon destruction
********************************************************************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugeAsteroidMovement : SpawnManager
{
    /* Written by LL */


    // Update is called once per frame, movement for this object is set to straight down
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    //on collision huge asteroid object is destroyed and two smallwer ones spawn in its place
    void OnTriggerEnter2D(Collider2D StruckObject)
    {
        if (StruckObject.tag != "Asteroid" && StruckObject.tag != "Bounds" && StruckObject.tag != "Planet" && StruckObject.tag != "Trail" && StruckObject.tag != "HugeAsteroid")
        {
            Destroy(gameObject);
            Instantiate(AsteroidLeftMovementPrefab, transform.position, transform.rotation); //whatever position and rotation the huge asteroid prefab is in will be where the two smaller ones spawn
            Instantiate(AsteroidRightMovementPrefab, transform.position, transform.rotation);
        }
        else if (StruckObject.tag == "Planet")
        {
            Destroy(gameObject);
        }
    }

    //Objects are destroyed after leaving the screen
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        
    }
    //Written by LL
}
