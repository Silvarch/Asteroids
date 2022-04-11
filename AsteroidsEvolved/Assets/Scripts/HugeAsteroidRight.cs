using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugeAsteroidRight : SpawnManager
{
    /* Written by LL */
    int CollisionCounter = 0;

    void Update()
    {
        if (CollisionCounter % 2 == 0)
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
        if (StruckObject.tag == "Asteroid" || StruckObject.tag == "HugeAsteroid" || StruckObject.tag == "Bounds")
        {
            CollisionCounter++;
        }
        else if (StruckObject.tag != "Asteroid" && StruckObject.tag != "Bounds" && StruckObject.tag != "Planet" && StruckObject.tag != "Trail" && StruckObject.tag != "HugeAsteroid")
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

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    /* Written by LL */
}
