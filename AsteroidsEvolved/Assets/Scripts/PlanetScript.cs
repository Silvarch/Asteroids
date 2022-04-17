/*******************************************************************************************************************************************************************
Program:Asteroids Evolved
Authors: Derrick Grant, Justin Perkins, Kyle Shaw, Logan Larocque
Date: April 17,2022
Class: PlanetScript
Purpose: Controls all interation with the Planet
Notes:Objects colliding with the planet are destroid and damage is assigned based on the object. Upon taking damage, the healthbar class is called to update the visual indicator.
********************************************************************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written by DG
public class PlanetScript : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public healthBar healthbar;
    public GameObject gameOverEvent;

    void start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.tag == "Asteroid")
        {
            Destroy(collide.gameObject);
            DamagePlanet(10);
        }
        else if (collide.gameObject.tag == "HugeAsteroid")
        {
            Destroy(collide.gameObject);
            DamagePlanet(20);
        }
    }
    void DamagePlanet(int damage)
    {
        currentHealth = currentHealth - damage;

        healthbar.SetHealth(currentHealth);

        if (currentHealth <= 0) {
            gameOverEvent.SetActive(true);
        }
    }


    public int getPlantHealth() {
        return currentHealth;
    }
    
    
    
}
//Written by DG