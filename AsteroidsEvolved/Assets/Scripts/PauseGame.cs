/*******************************************************************************************************************************************************************
Program:Asteroids Evolved
Authors: Derrick Grant, Justin Perkins, Kyle Shaw, Logan Larocque
Date: April 17,2022
Class: PauseGame
Purpose: Allows the player to pause the game at will
Notes: options are presented to the player to either resume or quit the game. quitting will take you back to the main menu
********************************************************************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Written by KS
public class PauseGame : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject canvasContent;
    private static bool isPaused = false;

    private void Update()
    {
        if (!GameOver.IsGameOver() && Input.GetKeyDown(KeyCode.Escape)) {
            isPaused = !isPaused;
            updateState();
        }
    }

    public void SetPaused(bool isPaused) {
        PauseGame.isPaused = isPaused;
        updateState();
    }

    private void updateState()
    {
        if (isPaused)
        {
            Time.timeScale = 0;
            canvasContent.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            canvasContent.SetActive(false);
        }
    }

    public static bool IsPaused() { 
        return isPaused;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
        isPaused = false;
    }

}
//Written by KS
