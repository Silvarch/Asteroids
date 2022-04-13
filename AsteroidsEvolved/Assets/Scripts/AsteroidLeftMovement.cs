using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidLeftMovement : SpawnManager
{
    /* Written by LL */
    int CollisionCounter = 0;

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

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    /* Written by LL */
}
