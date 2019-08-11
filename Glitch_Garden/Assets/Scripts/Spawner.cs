using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabs;
    public float spawnRate = 5f;

	
	// Update is called once per frame
	void Update () {
        //Spawn(attackerPrefabs[0]);
        foreach(GameObject thisAttacker in attackerPrefabs)
        {
            if (isTimeToSpawn(thisAttacker))
            {       
                Spawn(thisAttacker);
            }
        }
        // print("Time.deltaTime " + Time.deltaTime);
	}

    void Spawn(GameObject myGameObject)
    {

        GameObject myAttacker = Instantiate(myGameObject);
        myAttacker.transform.parent = transform;  //this.transform
        myAttacker.transform.position = transform.position;
    }

    bool isTimeToSpawn(GameObject attackerGameObject)
    {
        Attacker attacker = attackerGameObject.GetComponent<Attacker>();

        float meanSpawnDelay = attacker.seenEverySeconds;
        float spawnsPerSecond = 1 / meanSpawnDelay;

        if(Time.deltaTime > meanSpawnDelay)
        {
            Debug.LogWarning("Spawn rate capped by frame rate");
        }

        float threshold = spawnsPerSecond * Time.deltaTime / 5;
        return (Random.value < threshold);
        /*
        if (Random.value < threshold)
        {
            return true;
        }
        else
        {
            return false;
        }*/
        /*
        if(Time.time > spawnRate + lastSpawnTime)
        {
            lastSpawnTime = Time.time;
            return true;
        }
        return false;
        */
    }

}
