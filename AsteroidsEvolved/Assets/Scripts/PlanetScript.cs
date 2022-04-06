using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    /*
    public int currentHealth = 0;
    public int maxHealth = 100;

    public HealthBar healthbar;

    void start()
    {
        currentHealth = maxHealth;
    }
    */

    /*
    void Update()
    {
        
        void OnCollisionEnter2D(Collision2D collsion)
        {
            if (collsion.gameObject.tag == "Asteroid")
            {
                DamagePlanet(10);
            }
            else if (collsion.gameObject.tag == "HugeAsteroid")
            {
                DamagePlanet(20);
            }
        }
        
     
    }
    */

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Asteroid" || collision.gameObject.tag == "HugeAsteroid")
        {
            Destroy(collision.gameObject);
        }
    }

    /*
    void DamagePlanet(int damage)
    {
        currentHealth -= damage;

        healthBar.setHealth(currentHealth);
    }
    */
}