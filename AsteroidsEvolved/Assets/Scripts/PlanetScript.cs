using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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