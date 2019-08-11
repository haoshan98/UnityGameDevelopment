using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseCollider : MonoBehaviour {

    private LevelManager levelManager;

    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
    void OnTriggerEnter2D(Collider2D trigger)
    {
        print("Trigger");
        levelManager.LoadLevel("Loose Screen");
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }
}
