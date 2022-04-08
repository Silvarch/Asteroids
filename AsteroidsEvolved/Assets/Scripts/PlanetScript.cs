using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public healthBar healthbar;

    void start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    void update()
    {
        void OnCollisionEnter2D(Collision2D collide)
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
    }
    

    void DamagePlanet(int damage)
    {
        currentHealth = currentHealth - damage;

        healthbar.SetHealth(currentHealth);
    }



    
    
    
}