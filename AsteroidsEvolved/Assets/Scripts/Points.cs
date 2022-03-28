using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{

    private double currentPoints = 0;
    private readonly double ASTROID_VALUE = 10;
    private GameObject scoreTextDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore() {
        //CurrentPoints = Envirorments.AstroidsHit * ASTROID_VALUE;

        //update ScoreTextDisplay text

    }

    public void GetScore() {
        return currentPoints;
    }


}
