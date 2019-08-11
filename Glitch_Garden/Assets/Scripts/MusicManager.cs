using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;

    private AudioSource audioSource;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("DontDestroyOnLoad : " + name);
    }
    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        //looking for another component of this game object
    }
	
    //void OnLevelWasLoaded(int level)
    //{ }  

    private void OnEnable()  //this method is required to replace OnLevelWasLoaded().
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // subscribe
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(loadSceneMode);
        AudioClip thisLevelMusic = levelMusicChangeArray[scene.buildIndex];
        Debug.Log("Playing clip : " + thisLevelMusic);
        if (thisLevelMusic)  //if there is some music attached/exist
        {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }

    }
    private void OnDisable()  //this method is required to replace OnLevelWasLoaded().
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; //unsubscribe
    }

    public void ChangeVolume(float volumeLevel)
    {
        audioSource.volume = volumeLevel;
    }
}
