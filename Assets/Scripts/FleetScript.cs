using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FleetScript : MonoBehaviour
{
    public float moveTime = 1;
    public float moveSpeed = 0.8f;
    int moveCounter = 0;
    int moveDirection;
    public bool isGameRunning;
    public TMP_Text endText;

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

        endText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameRunning && transform.childCount == 0)
        {
            StopGame(true);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void StopGame(bool isWin)
    {
        CancelInvoke("Move");
        isGameRunning = false;

        endText.gameObject.SetActive(true);
        endText.text = isWin ? "You win!!" : "You lose!!";
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
