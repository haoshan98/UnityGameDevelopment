﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public AudioClip crack;
    [SerializeField] public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public GameObject smoke;

    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;
    private GameObject startColor;

	// Use this for initialization
	void Start ()
    {
        isBreakable = (this.tag == "Breakable");
        //Keep track of breakable bricks
        if (isBreakable)
        {
            breakableCount++;
        }
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position, 0.8f);
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            PuffSmoke();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void PuffSmoke()
    {
        //Instantiate(smoke, new Vector3(this.transform.position.x, this.transform.position.y, 0f), Quaternion.identity);
        GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
        ParticleSystem.MainModule mainSettings = smokePuff.GetComponent<ParticleSystem>().main;
        mainSettings.startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void LoadSprites()
    {
        int spritesIndex = timesHit - 1;
        if (hitSprites[spritesIndex] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spritesIndex];
        }
        else
        {
            //Guard code, make error for checking yourself
            Debug.LogError("Brick sprite missing");
        }
    }

    // TODO Remove this method once we can actually win!
    void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }
}
