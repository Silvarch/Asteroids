using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written by JP
public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletTemplate;
    public AudioSource shootSound;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && PauseGame.IsPaused() == false)
        {
             shootProjectile();
        }
    }

    private void shootProjectile()
    {
        Instantiate(bulletTemplate, firePoint.position, firePoint.rotation);

        shootSound.Play();
    }
}
//Written by JP