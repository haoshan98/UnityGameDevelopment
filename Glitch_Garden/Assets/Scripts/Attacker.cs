using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    [Tooltip ("Average number of seconds between appearances")]
    public float seenEverySeconds;
    //[Range(-1f, 1.5f)] public float currentWalkSpeed;
    private float currentWalkSpeed;
    private GameObject currentTarget;
    
	// Use this for initialization
	void Start () {
        //Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
        //myRigidbody.bodyType = RigidbodyType2D.Kinematic;
    }
	
	// Update is called once per frame
	void Update () {
        moving();
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
	}

    
    public void moving()
    {
        transform.Translate(Vector3.left * currentWalkSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log(name + " collided by " + collider);
    }

    public void SetSpeed(float speed)
    {
        currentWalkSpeed = speed;
    }

    //Called from the animator ot the time of actual blow
    public void StrikeCurrentTarget(float damage)
    {
        //Debug.Log(name + " is attacking, caused damage " + damage);
        if (currentTarget) //if currentTarget exist
        {
            Health health = currentTarget.GetComponent<Health>();  //Get the health comp of current target
            if (health)
            {
                health.DealDamage(damage);
            }
        }
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
        //health = obj.GetComponent<Health>();
        //health.health -= 5f;
        //Debug.Log("Health of " + currentTarget + " is " + health.health);
    }
}
 