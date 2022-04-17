/*******************************************************************************************************************************************************************
Program:Asteroids Evolved
Authors: Derrick Grant, Justin Perkins, Kyle Shaw, Logan Larocque
Date: April 17,2022
Class: StartAScene
Purpose: Allows for scene transfers
Notes: 
********************************************************************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// Written by KS
public class StartAScene : MonoBehaviour
{

    public string SceneName;

    public void startScene() {
        SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
    }

}
// Written by KS
