using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    public void LoadLevel(string name)
    {
        Debug.Log("New Level load:" + name);
        Brick.breakableCount = 0;
        SceneManager.LoadScene(name);
    }

    //when win, go next scene
    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Brick.breakableCount = 0;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 0)
        {
            LoadNextLevel();
        }
    }
}
