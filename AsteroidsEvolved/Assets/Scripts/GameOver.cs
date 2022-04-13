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

    public void setScore(int score, int bonusMultiplierScore, int totalScore) {
        scoreTxt.text = score.ToString();
        bonusMultiplierScoreTxt.text = bonusMultiplierScore.ToString();
        this.totalScoreTxt.text = totalScore.ToString();
    }

    public void setScore() //temporary used until multiplier score is also added
    {
        scoreTxt.text = points.GetScore().ToString();
        bonusMultiplierScoreTxt.text = points.CalculateMultiplier().ToString();
        totalScoreTxt.text = points.CalculateTotalScore(points.GetScore(), points.CalculateMultiplier()).ToString();
        gameOverCheck = true;
    }

    public static bool IsGameOver() {
        return gameOverCheck;
    }

    private void OnDestroy()
    {
        gameOverCheck = false;
    }

}
