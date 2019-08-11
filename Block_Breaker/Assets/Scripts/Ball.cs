using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    
    private Paddle paddle;
    private Rigidbody2D rigidBody;
    private bool hasStarted = false;
    private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        rigidBody = GameObject.FindObjectOfType<Rigidbody2D>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted)
        {
            //let ball stick to the paddle before launching the ball
            this.transform.position = paddle.transform.position + paddleToBallVector;

            //Wait for the mouse press for launch
            if (Input.GetMouseButtonDown(0))
            {
                print("Mouse clicked, launching the ball");
                hasStarted = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-2f, 15f);
            }
        }
	}

    void OnCollisionEnter2D(Collision2D collision )
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            //rigidBody.velocity += tweak;
            GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }
}
