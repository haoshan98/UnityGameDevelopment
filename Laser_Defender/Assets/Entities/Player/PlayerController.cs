using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 5.0f;
    public float padding = 1f;

    public GameObject projectile;//laserPrefab;
    public float projectileSpeed;
    public float firingRate = 0.1f;
    public static float playerHealth = 5000f;

    public AudioClip fireSound;


    float xmin;
    float xmax;

    void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x + padding;
        xmax = rightmost.x - padding;
    }

    void Fire()
    {
        //Vector3 startPosition = transform.position + new Vector3(0f, 0.7f, 0f);
        GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity);
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, projectileSpeed, 0f);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.000001f, firingRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }

        if (Input.GetKey (KeyCode.LeftArrow))
        { 
            //this.transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if(Input.GetKey (KeyCode.RightArrow))
        {
            //this.transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
            this.transform.position += Vector3.right * speed * Time.deltaTime;
            
            //Time.deltaTime: make sure movement is independent of framerate
        }

        //restrict the player to the gamespace
        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        //shoot();
    }
    /*Vector3 shipPos = new Vector3(this.transform.position.x, this.transform.position.y, 0f);
        if (Input.GetKey (KeyCode.LeftArrow))
        { 
            shipPos.x -= speed* Time.deltaTime;
            this.transform.position = shipPos;
        }
        else if(Input.GetKey (KeyCode.RightArrow))
        {
            shipPos.x += speed* Time.deltaTime;
            this.transform.position = shipPos;
        }
        //Time.deltaTime: make sure movement is independent of framerate
        */

    public void shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity);
            laser.transform.position += Vector3.up * 5 * Time.deltaTime;
        }
    }

    public static void ResetHealthPoint()
    {
        playerHealth = 5000f;
    }
    ///////////////////////////////////////////////////////////////////////////////
    //Shoot by enemy
    public void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log(collider);
        Projectile missile = collider.gameObject.GetComponent<Projectile>();
        if (missile)  //missile exist
        {
            playerHealth -= missile.GetDamage();
            HealthKeeper.HP(missile.GetDamage());
            missile.Hit();
            if (playerHealth <= 0)
            {
                Die();
            }
            Debug.Log("Hit by enemy"  + playerHealth + " " + gameObject.GetInstanceID());
        }
    }

    void Die()
    {
        LevelManager levelMan = GameObject.Find("LevelManager").AddComponent<LevelManager>();
        Destroy(gameObject);
        levelMan.LoadNextLevel();
        PlayerController.ResetHealthPoint();
    }
}
