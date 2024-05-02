using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class collidablePlayerMovementMP : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    public float playerSpeedCoefficient; // effects the movement speed of the player
    public Camera cam1; // the main camera, used for player position determination
	private Vector2 movement;
	public GameObject GameOver;

    public Slider hb;

    public int player = 0;

    public int health = 100;
    public int score = 0;
    public float fscore = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }
    void Update()
    {
        movement = new Vector2(0f, 0f).normalized;
        if (player == 0)
        {
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
            {
                movement = new Vector2(-1f, 1f).normalized;
            }
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                movement = new Vector2(1f, 1f).normalized;
            }
            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
            {
                movement = new Vector2(1f, -1f).normalized;
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            {
                movement = new Vector2(-1f, -1f).normalized;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                movement = new Vector2(0f, 1f).normalized;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                movement = new Vector2(-1f, 0f).normalized;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                movement = new Vector2(0f, -1f).normalized;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                movement = new Vector2(1f, 0f).normalized;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.I))
            {
                movement = new Vector2(-1f, 1f).normalized;
            }
            else if (Input.GetKey(KeyCode.I) && Input.GetKey(KeyCode.L))
            {
                movement = new Vector2(1f, 1f).normalized;
            }
            else if (Input.GetKey(KeyCode.L) && Input.GetKey(KeyCode.K))
            {
                movement = new Vector2(1f, -1f).normalized;
            }
            else if (Input.GetKey(KeyCode.K) && Input.GetKey(KeyCode.J))
            {
                movement = new Vector2(-1f, -1f).normalized;
            }
            else if (Input.GetKey(KeyCode.I))
            {
                movement = new Vector2(0f, 1f).normalized;
            }
            else if (Input.GetKey(KeyCode.J))
            {
                movement = new Vector2(-1f, 0f).normalized;
            }
            else if (Input.GetKey(KeyCode.K))
            {
                movement = new Vector2(0f, -1f).normalized;
            }
            else if (Input.GetKey(KeyCode.L))
            {
                movement = new Vector2(1f, 0f).normalized;
            }

        }

        updateHealthbar(health);

        if (health < 1 && !GameOver.activeSelf){
            GameOver.SetActive(true);
			Time.timeScale = 0;
		}

    }
	void FixedUpdate()
	{
		rotateCheck();
		moveCharacter(movement);
    }
    public void rotateCheck()
    {
        if (player == 0)
        {
            if (Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.T))
            {
                playerRigidbody.rotation = 135f;
            }
            else if (Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.G))
            {
                playerRigidbody.rotation = 225f;
            }
            else if (Input.GetKey(KeyCode.G) && Input.GetKey(KeyCode.H))
            {
                playerRigidbody.rotation = 315f;
            }
            else if (Input.GetKey(KeyCode.H) && Input.GetKey(KeyCode.T))
            {
                playerRigidbody.rotation = 45f;
            }
            else if (Input.GetKey(KeyCode.F))
            {
                playerRigidbody.rotation = 180f;
            }
            else if (Input.GetKey(KeyCode.T))
            {
                playerRigidbody.rotation = 90f;
            }
            else if (Input.GetKey(KeyCode.H))
            {
                playerRigidbody.rotation = 0.0f;
            }
            else if (Input.GetKey(KeyCode.G))
            {
                playerRigidbody.rotation = 270f;
            }
        } else
        {
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                playerRigidbody.rotation = 135f;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
            {
                playerRigidbody.rotation = 225f;
            }
            else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
            {
                playerRigidbody.rotation = 315f;
            }
            else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                playerRigidbody.rotation = 45f;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                playerRigidbody.rotation = 180f;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                playerRigidbody.rotation = 90f;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                playerRigidbody.rotation = 0.0f;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                playerRigidbody.rotation = 270f;
            }


        }



    }
	void moveCharacter(Vector3 direction)
    {
        // We multiply the 'speed' variable to the Rigidbody's velocity...
        // and also multiply 'Time.fixedDeltaTime' to keep the movement consistant on all devices
        playerRigidbody.velocity = direction * playerSpeedCoefficient * Time.fixedDeltaTime;
    }

    void updateHealthbar(int h)
    {
        hb.value = (float)(h / 100.0);
    }

}
