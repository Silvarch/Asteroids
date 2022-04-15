using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update

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
