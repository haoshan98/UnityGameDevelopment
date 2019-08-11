using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class GameTimer : MonoBehaviour {

    public float levelTimeinSeconds = 100;

    private Slider slider;
    private AudioSource audioSource;
    private LevelManager levelManager;
    //public float secondsLeft;  //use Time.timeSinceLevelLoad instead
    private bool isEndOfLevel = false;
    private GameObject winLabel;
    
	// Use this for initialization
	void Start ()
    {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        FindYouWin();
        winLabel.SetActive(false);

        //secondsLeft = levelTimeinSeconds;
    }

    private void FindYouWin()
    {
        winLabel = GameObject.Find("You Win");
        if (!winLabel)
        {
            Debug.LogWarning("Please create You Win object");
        }
    }

    // Update is called once per frame
    void Update () {
        //slider.value = 1 - (secondsLeft / levelTimeinSeconds);
        slider.value = Time.timeSinceLevelLoad / levelTimeinSeconds;  //make sure the slider value between 0 and 1
        bool timeIsUp = (Time.timeSinceLevelLoad >= levelTimeinSeconds);
        if (timeIsUp && !isEndOfLevel)
        {
            isEndOfLevel = true;
            audioSource.Play();
            //EditorUtility.DisplayDialog("Congratulation", "You killed all the attackers!", "Proceed", "Play Again");
            winLabel.SetActive(true);
            Invoke("LoadNextLevel", audioSource.clip.length);
            //levelManager.Invoke("LoadNextLevel", audioSource.clip.length);
        }
	}

    void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }

}
