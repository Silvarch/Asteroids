/*******************************************************************************************************************************************************************
Program:Asteroids Evolved
Authors: Derrick Grant, Justin Perkins, Kyle Shaw, Logan Larocque
Date: April 17,2022
Class: GameOver
Purpose: checks for conditions that would trigger the "Game Over" screen. displays updated score
Notes: If Game Over is true, the score is updated by calling methods from the points class. Screen is displayed with score along with all modifiers
********************************************************************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Written by KS
public class GameOver : MonoBehaviour
{

    private static bool gameOverCheck = false;

    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI bonusMultiplierScoreTxt;
    public TextMeshProUGUI totalScoreTxt;

    public Points points;

    public void OnEnable()
    {
        gameOverCheck = true;
        GetComponent<PauseGame>().SetPaused(true);
        setScore();
    }

    private void setScore()
    {
        scoreTxt.text = points.GetScore().ToString();
        bonusMultiplierScoreTxt.text = points.CalculateMultiplier().ToString() + "x";
        totalScoreTxt.text = points.CalculateTotalScore(points.GetScore(), points.CalculateMultiplier()).ToString();
    }

    public static bool IsGameOver() {
        return gameOverCheck;
    }

    private void OnDestroy()
    {
        gameOverCheck = false;
    }

}
// Written by KS