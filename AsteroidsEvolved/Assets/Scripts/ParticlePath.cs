/*******************************************************************************************************************************************************************
Program:Asteroids Evolved
Authors: Derrick Grant, Justin Perkins, Kyle Shaw, Logan Larocque
Date: April 17,2022
Class: ParticlePath
Purpose: to create partilce systems that trail behind each asteroid gameObject
Notes: A particle path clsss was used in conjuntion with the built in unity particle system. The purpose is to create a trailing effect on all asteroids.
When gameObjects containing this script are instantiated, a particle system is spawned on the same location with the same directional movement as that gameObject.
The colliders are also identical to each respective asteroid. When an asteroid is hit, so is the ParticleSystem's collider. When struck the object remains on its
tragectory, however it will stop spawning particles. This allows particles to naturally despawn instead of abruptly disapearing all at once
********************************************************************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Written by LL
public class ParticlePath : SpawnManager
{
    public int CollisionCounter = 0; //used to allow particle trails to follow richocheting asteroids
    bool IsHuge; //checks to see if asteroid created is large, if so this method is intended to create trails for the smaller astroids that are created in this scenario. NOT COMPLETE
    string Direction = AsteroidType; //variable used to determin the trail pattern. this variable must be used because 'AsteroidType" is in the update method of  the SpawnManager class

    CircleCollider2D Collider; //object references used to adjust colliders in code
    ParticleSystem Particles; 


    //object references are set on start as components of an object are not static so they cannot be changed directly
    void Start()
    {
        Collider = GetComponent<CircleCollider2D>();
        Particles = GetComponent<ParticleSystem>();
    }
    // Update is called once per frame, the path that is spawned will directly correlate with the asteroid Object that spawns at the same time. this allows for trrail movement to be hard coded and still follow an identical path to any asteroid
    void Update()
    {
        
        //switch statement determines the particle trails path after being instantiated and sets the collision box size. The particle is seperate from each asteroid so that the trail does not abruptly disappear when an asteroid is destroyed
        switch (Direction)
        {
            case "Down":
                Collider.radius = 1.7f;               
                transform.Translate(Vector3.down * speed * Time.deltaTime);
                break;

            case "Right":
                Collider.radius = 1.7f;

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

                break;

            case "Left":
                Collider.radius = 1.7f;
                if (CollisionCounter % 2 == 1)
                {
                    transform.Translate(Vector3.down * speed * Time.deltaTime);
                    transform.Translate(Vector3.left * speed * Time.deltaTime);
                }
                else
                {
                    transform.Translate(Vector3.down * speed * Time.deltaTime);
                    transform.Translate(Vector3.right * speed * Time.deltaTime);
                }
                break;

            case "HugeDown":
                Collider.radius = 1.6f;
                IsHuge = true;
                transform.Translate(Vector3.down * speed * Time.deltaTime);
                break;

            case "HugeRight":
                Collider.radius = 1.6f;
                IsHuge = true;
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
                break;

            case "HugeLeft":
                Collider.radius = 1.6f;
                IsHuge = true;
                if (CollisionCounter % 2 == 1)
                {
                    transform.Translate(Vector3.down * speed * Time.deltaTime);
                    transform.Translate(Vector3.left * speed * Time.deltaTime);
                }
                else
                {
                    transform.Translate(Vector3.down * speed * Time.deltaTime);
                    transform.Translate(Vector3.right * speed * Time.deltaTime);
                }

                break;
        }
    }
    //Ensures that when an asteroid strikes another asteroid or the invisible bounds that the particle effect will follow it
    void OnTriggerEnter2D(Collider2D StruckObject)
    {
        if (StruckObject.tag == "Asteroid" || StruckObject.tag == "HugeAsteroid" || StruckObject.tag == "Bounds")
        {
            CollisionCounter++;



        }
        else if (StruckObject.tag != "Asteroid" && StruckObject.tag != "Bounds" && StruckObject.tag != "Trail" && StruckObject.tag != "HugeAsteroid")
        {
            var emission = Particles.emission;
            emission.rateOverTime = 0;
            Collider.radius = 0;

            /*if (IsHuge == true) //currently a trail is not added to astroids created by a larger one ADD THIS
            {
                Instantiate(ParticleSystemPrefab, transform.position, transform.rotation);
                Instantiate(ParticleSystemPrefab, transform.position, transform.rotation);
            }*/

        }

    else if (StruckObject.tag == "Delete") //if ibject collides with deletion box off camera it is then destroyed
        {
            Destroy(gameObject);
        }
    }

    //particle objects are destroyed after becoming invisible
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
//Written by LL
