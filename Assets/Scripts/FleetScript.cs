using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetScript : MonoBehaviour
{
    public float moveTime = 1;
    public float moveSpeed = 0.8f;
    int moveCounter = 0;
    int moveDirection;
    public bool isGameRunning;

    // Start is called before the first frame update
    void Start()
    {
        moveDirection = 1;
        StartGame();
    }

    public void StartGame()
    {
        InvokeRepeating("Move", moveTime, moveTime);
        isGameRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameRunning && transform.childCount == 0)
        {
            StopGame(true);
        }
    }

    public void StopGame(bool isWin)
    {
        CancelInvoke("Move");
        isGameRunning = false;
    }

    void Move()
    {
        transform.position += new Vector3(moveSpeed * moveDirection, 0, 0);
        moveCounter += moveDirection;

        if (moveCounter <= -4 || moveCounter >= 4)
        {
            moveDirection *= -1;
            transform.position -= new Vector3(0, moveSpeed, 0);
        }
    }
}
