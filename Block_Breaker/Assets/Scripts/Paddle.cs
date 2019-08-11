﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    public float minX = 1f, maxX = 15f;

    private Ball ball;


    private void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }
    // Update is called once per frame
    void Update () {
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
    }

    void MoveWithMouse()
    {
        //this.transform.position.y
        Vector3 paddlePos = new Vector3(0.5f, 0.5f, 0f);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);
        this.transform.position = paddlePos;
        //this- refer to the current script(Paddle script)
    }

    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(0.5f, 0.5f, 0f);
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);
        this.transform.position = paddlePos;
    }
}
 