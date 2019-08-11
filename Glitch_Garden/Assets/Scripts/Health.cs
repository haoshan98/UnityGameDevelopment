using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float health = 100f;

	
	// Update is called once per frame
	void Update () {
		
	}

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DestroyObject();
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
