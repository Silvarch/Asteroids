using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAScene : MonoBehaviour
{

    public string SceneName;

    public void startScene() {
        SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
    }

}
