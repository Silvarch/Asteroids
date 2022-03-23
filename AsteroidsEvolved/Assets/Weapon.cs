using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletTemplate;
    public AudioSource shootSound;

    void Update()
    {
        if (!PauseGame.IsPaused())
        {
            if (Input.GetButtonDown("Fire1"))
            {
                shootProjectile();
            }
        }
       
    }

    private void shootProjectile()
    {
        Instantiate(bulletTemplate, firePoint.position, firePoint.rotation);

        shootSound.Play();
    }
}
