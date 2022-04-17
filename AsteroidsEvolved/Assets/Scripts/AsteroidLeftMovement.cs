/*******************************************************************************************************************************************************************
Program:Asteroids Evolved
Authors: Derrick Grant, Justin Perkins, Kyle Shaw, Logan Larocque
Date: April 17,2022
Class: AsteroidLeftMovement
Purpose: Controls movment of the asteroid gameObject to which this script is attatched to.
Notes: Rules are set in place to change direction upon collision with a boundry or asteroid as can be seen via the collisionDetector integer
********************************************************************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidLeftMovement : SpawnManager
{
    /* Written by LL */
    int CollisionCounter = 0;

    // Update is called once per frame, directional movmement is determined by CollisionCounter. this code allows for Objects to bounce off walls.
    void Update()
    {
        if (CollisionCounter % 2 == 1)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    // Objects are destroyed upon collision with specific Objects. other collisions increase collision counter to allow for bounces
    void OnTriggerEnter2D(Collider2D StruckObject)
    {
        if (StruckObject.tag == "Asteroid" || StruckObject.tag == "Bounds" || StruckObject.tag == "HugeAsteroid")
        {
            CollisionCounter++;
        }
        else if (StruckObject.tag != "Asteroid" && StruckObject.tag != "Bounds" && StruckObject.tag != "HugeAsteroid" && StruckObject.tag != "Trail")
        {
            Destroy(gameObject);
        }
    }

    //Ibjects are destroyed after leaving the screen
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    /* Written by LL */
}
