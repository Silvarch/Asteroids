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
    private TextMeshProUGUI visualScore;

    // Start is called before the first frame update
    void Start()
    {
        visualScore = scoreTextDisplay.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

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
