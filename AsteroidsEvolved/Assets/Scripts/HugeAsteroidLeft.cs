using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugeAsteroidLeft : SpawnManager
{
    /* Written by LL */
    
    int CollisionCounter = 0;

    void Update()
    {
        if (CollisionCounter % 2 == 1)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D StruckObject)
    {
        if (StruckObject.tag == "Asteroid" || StruckObject.tag == "Bounds")
        {
            CollisionCounter++;
        }
        else if (StruckObject.tag != "Asteroid" && StruckObject.tag != "Bounds" && StruckObject.tag != "Trail")
        {
            Destroy(gameObject);
            Instantiate(AsteroidLeftMovementPrefab, transform.position, transform.rotation); //whatever position and rotation the huge asteroid prefab is in will be where the two smaller ones spawn
            Instantiate(AsteroidRightMovementPrefab, transform.position, transform.rotation);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    //Written by LL
}
