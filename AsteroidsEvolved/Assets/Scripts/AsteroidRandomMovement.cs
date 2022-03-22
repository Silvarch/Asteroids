using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRandomMovement : MonoBehaviour
{
    /* Written by LL */
    float speed = 2;



    void Update()
    {
        int RandomDirection = Randomizer();



        if (RandomDirection % 2 == 0)
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
    int Randomizer()
    {
        int RandomNumber = Random.Range(0, 100);
        return RandomNumber;
    }
    void OnTriggerEnter2D(Collider2D StruckObject)
    {
        if (StruckObject.tag != "Asteroid" && StruckObject.tag != "Bounds")
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
