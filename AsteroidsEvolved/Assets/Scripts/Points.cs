/*******************************************************************************************************************************************************************
Program:Asteroids Evolved
Authors: Derrick Grant, Justin Perkins, Kyle Shaw, Logan Larocque
Date: April 17,2022
Class: Points
Purpose: creates visual indicators and backend recording of points scored
Notes: Player can see their current points at all times while playing without the modifier of planet health whcih is displayed at game over
********************************************************************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Written by KS
public class Points : MonoBehaviour
{

    private double currentPoints = 0;
    private double AstroidPointValue = 10;
    [SerializeField] private GameObject scoreTextDisplay;
    [SerializeField] private PlanetScript planetHealth;
    private TextMeshProUGUI visualScore;

    // Start is called before the first frame update
    void Start()
    {
        visualScore = scoreTextDisplay.GetComponent<TextMeshProUGUI>();
    }

    public double CalculateMultiplier() { 
        return (planetHealth.getPlantHealth() / 100.0) + 1.0;
    }

    public double CalculateTotalScore(double score, double multiplier) {
        return score * multiplier;
    }

    public void UpdateScore()
    {
        currentPoints += AstroidPointValue;

        //update ScoreTextDisplay text
        visualScore.text = currentPoints.ToString();
    }

    public double GetScore()
    {
        return currentPoints;
    }


}
//Written by KS
