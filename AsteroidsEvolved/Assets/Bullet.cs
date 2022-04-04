using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Writenby KS
public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rd;
    GameObject player;
    //public AudioSource impactSound;

    // Start is called before the first frame update
    void Start()
    {
        rd.velocity = transform.right * speed;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Trail") //trails will still be on screen after being hit to allow for natural deletion of particles. rule set in place so that bullets do not bounce off trail rigidbodies
        {
            Destroy(gameObject);
        }
        if (collision.tag == "Asteroid")
        {
            player.GetComponent<Points>().UpdateScore();
            
        }
    }
}
//Written by KS
