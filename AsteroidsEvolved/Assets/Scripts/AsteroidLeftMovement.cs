using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidLeftMovement : MonoBehaviour
{
    /* Written by LL */
    float speed = 2;
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
        if (StruckObject.tag == "Asteroid" || StruckObject.tag == "Boundry")
        {
            CollisionCounter++;
        }
    }
    /* Written by LL */
}
