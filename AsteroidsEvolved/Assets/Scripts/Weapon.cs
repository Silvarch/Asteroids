/*******************************************************************************************************************************************************************
Program:Asteroids Evolved
Authors: Derrick Grant, Justin Perkins, Kyle Shaw, Logan Larocque
Date: April 17,2022
Class: Weapon
Purpose: framework that allows for the firing of projectiles
Notes: If fire button is pressed an projectile is created and sent in the direction the player is facing.
********************************************************************************************************************************************************************/

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