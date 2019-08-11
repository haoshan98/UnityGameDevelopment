using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public float EnemyHealth = 550f;
    public GameObject projectile;//laserPrefab;
    public float projectileSpeed = 10f;
    public float shotsPerSeconds = 0.6f;
    public AudioClip hurtSound;
    public AudioClip deadSound;
    public AudioClip fireSound;
    private int scoreValue = 180;

    private ScoreKeeper scoreKeeper;

    private void Start()
    {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();    
    }

    private void Update()
    {
        float probability = Time.deltaTime * shotsPerSeconds;  //probability bet 0 & 1
        if (Random.value < probability) {  //80% true
            Fire();
        }
    }

    void Fire()
    {
        //Vector3 startPosition = transform.position + new Vector3(0f, -0.7f, 0f);
        GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity);
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, -projectileSpeed, 0f);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        AudioSource.PlayClipAtPoint(hurtSound, transform.position);
        //Debug.Log(collider);
        Projectile missile = collider.gameObject.GetComponent<Projectile>();
        if (missile)  //missile exist
        {
            EnemyHealth -= missile.GetDamage();
            missile.Hit();
            if(EnemyHealth <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        AudioSource.PlayClipAtPoint(deadSound, transform.position);
        Destroy(gameObject);
        scoreKeeper.Score(scoreValue);
    }
}
