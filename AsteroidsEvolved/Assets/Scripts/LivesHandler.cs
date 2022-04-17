/*******************************************************************************************************************************************************************
Program:Asteroids Evolved
Authors: Derrick Grant, Justin Perkins, Kyle Shaw, Logan Larocque
Date: April 17,2022
Class: LivesHandler
Purpose: handles all aspects of the player lives system
Notes: Player starts with three lives. lives are removed uppon collision with asteroids. A vidual indicator is displayed on the screen which is also updated with the current amount of lives
********************************************************************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Written by KS
public class LivesHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] lifeIndicators;
    public int currentLives = 3;
    public Color lifeDisabledColor = new Color(17.65f, 17.65f, 17.65f);
    public GameObject GameOverEvent;

    void Start()
    {
        updateLifeIndicator(currentLives);
    }

    public void decreaseLife() {
        currentLives--;
        updateLifeIndicator(currentLives);

        if (currentLives <= 0) {
            GameOver();
        }
    }
    
    public void updateLifeIndicator(int lives) {
        for(int i = 0; i < 3; i++) {
            if (i < currentLives)
            {
                lifeIndicators[i].GetComponent<Image>().color = Color.white;
            }
            else {
                lifeIndicators[i].GetComponent<Image>().color = lifeDisabledColor;
            }
        }

        if (!IsLivesLeft())
        {
            GameOver();
        }

    }

    public bool IsLivesLeft() {
        if(currentLives > 0){
            return true;
        }
        return false;
    }

    public void GameOver() {
        GameOverEvent.SetActive(true);
    }
    
}
// Written by KS
