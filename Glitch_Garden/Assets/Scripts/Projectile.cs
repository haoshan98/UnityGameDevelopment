using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed, damage;

    private GameObject currentTarget;

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

    //private void OnBecameInvisible()
    //{//sprite renderer is on the body of corgette, body become invisible, corgette never bocome invisible
    //    Destroy(gameObject);
    //}
 
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //currentTarget = collider.gameObject;
        Attacker currentTarget = collider.gameObject.GetComponent<Attacker>();
        //if (currentTarget && currentTarget.GetComponent<Attacker>()) //if currentTarget exist
        if (currentTarget) //if currentTarget exist
        {
            Health health = currentTarget.GetComponent<Health>();  //Get the health comp of current target
            if (health)
            {
                health.DealDamage(damage);
                Destroy(gameObject); //destroy the projectile itself
            }
        }
        /*
        Attacker currentTarget = collider.gameObject.GetComponent<Attacker>();
        Health health = currentTarget.GetComponent<Health>();  //Get the health comp of current target
        if (currentTarget && health) //if currentTarget exist
        {
              health.DealDamage(damage);
              Destroy(gameObject);
        }*/
    } 

}
