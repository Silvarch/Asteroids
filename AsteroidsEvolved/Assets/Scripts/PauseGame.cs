using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject canvasContent;
    [SerializeField] private static bool isPaused = false;

    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            updateState();
        }
    }

    public void IsPaused(bool isPaused) {
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
    }

}
