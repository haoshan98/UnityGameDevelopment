using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public GameObject laserPrefab;
    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //shoot();
	}

    public void shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject laser = Instantiate(laserPrefab, player.transform.position, Quaternion.identity);
            laser.transform.position += Vector3.up * 5 * Time.deltaTime;
        }
    }
}
