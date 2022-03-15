using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    /* Written by LL */
    float speed = 2;



    void Update()
    {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
