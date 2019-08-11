using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public float autoLoadNextLevelAfter;

    void Start()
    {
        //for Splash Screen
        if(autoLoadNextLevelAfter <= 0)
        {
            Debug.Log("Level auto load disabled, use a positive number in seconds");
        }
        else
        {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
    }
    
    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    //when win, go next scene
    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    
    public void LoadStartScene()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
