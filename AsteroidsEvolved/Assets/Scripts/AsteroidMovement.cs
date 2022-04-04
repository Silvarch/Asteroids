using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : SpawnManager
{
    /* Written by LL */


    void Update()
    {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D StruckObject)
    {
        if (StruckObject.tag != "Asteroid" && StruckObject.tag != "Bounds" && StruckObject.tag != "Trail")
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
