using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRightMovement : MonoBehaviour
{
    /* Written by LL */
    float speed = 2;
    int CollisionCounter = 0;

    void Update()
    {
        if (CollisionCounter % 2 == 0)
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
    }
    /* Written by LL */
}
