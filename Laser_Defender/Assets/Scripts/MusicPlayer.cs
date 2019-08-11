using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {
    static MusicPlayer instance = null;

    public AudioClip startClip;
    public AudioClip gameClip;
    public AudioClip endClip;

    private AudioSource music;

    void Awake()
    {
        if (instance != null && instance != this)  //avoid destroy the last one
        {
            Destroy(gameObject);
            print("Duplicate music player self-destructing!");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);  //gameObject is the instant of the music player
            music = GetComponent<AudioSource>();

            //first time the game start not execute OnLevelWasLoaded method
            music.clip = startClip;
            music.loop = true; //music play forever
            music.Play();
        }

    }

    // Use this for initialization
    void Start () {

    }
    /*
    private void OnLevelWasLoaded(int level)
    {
        Debug.Log("MusicPlayer: loaded level " + level);
        music.Stop();

        if (level == 0)
            music.clip = startClip;
        else if (level == 1)
            music.clip = gameClip;
        else if (level == 2)
            music.clip = endClip;

        music.loop = true; //music play forever
        music.Play();
    }
    */
    private void OnEnable()  //this method is required to replace OnLevelWasLoaded().
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // subscribe
    }
    private void OnDisable()  //this method is required to replace OnLevelWasLoaded().
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; //unsubscribe
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        Debug.Log("MusicPlayer: Loaded level " + scene.name);
        music = GetComponent<AudioSource>();
        music.Stop();
        if (scene.name == "Start Menu")  //switched to scene.name since the previous methodology didn't work. 
        {
            music.clip = startClip;
        }
        if (scene.name == "Game")
        {
            music.clip = gameClip;
        }
        if (scene.name == "Win Screen")
        {
            music.clip = endClip;
        }
        music.loop = true;
        music.Play();
    }


}
