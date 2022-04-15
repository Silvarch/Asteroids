using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesHandler : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject[] lifeIndicators;
    public int currentLives = 3; // testing purposes only
    public Color lifeDisabledColor = new Color(17.65f, 17.65f, 17.65f);
    public GameObject GameOverEvent;

    void Start()
    {
        lifeIndicators = GameObject.FindGameObjectsWithTag("LifeIndicator");
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
