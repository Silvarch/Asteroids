using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugeAsteroidMovement : SpawnManager
{
    /* Written by LL */



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

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        
    }
    //Written by LL
}
