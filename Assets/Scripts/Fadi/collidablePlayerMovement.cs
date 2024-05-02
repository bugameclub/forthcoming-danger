using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class collidablePlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    public float playerSpeedCoefficient; // effects the movement speed of the player
    public Camera cam1; // the main camera, used for player position determination
	private Vector2 movement;
	
	public GameObject GameOver;
	
	public int health = 100;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }
    void Update()
    {
		movement = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")).normalized;
		if(health < 1){
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
         Vector3 playerPos = cam1.WorldToScreenPoint(playerRigidbody.position); // gets player position on screen
         Vector3 mousePos = Input.mousePosition; // gets mouse position on screen

         if (mousePos.x >= playerPos.x) // if the mouse is to the right of or in line with the player
         {
             float mouseXP = mousePos.x - playerPos.x; // relative x position of the mouse to the player
             float mouseYP = mousePos.y - playerPos.y; // relative y position of the mouse to the player
             double angleP = Math.Atan(mouseYP / mouseXP) * (180 / Math.PI); // calculates the angle from the player to the mouse, then converts to degrees

             playerRigidbody.rotation = (float)(angleP); // sets player rotation to that angle
         }
         else // if the mouse is to the left
         {
             float mouseXP = mousePos.x - playerPos.x;
             float mouseYP = mousePos.y - playerPos.y;
             double angleP = (Math.Atan(mouseYP / mouseXP) + Math.PI) * (180 / Math.PI); // only difference is adding pi to correct for the limited range of arctan

             playerRigidbody.rotation = (float)(angleP);
         }
    }
	void moveCharacter(Vector3 direction)
    {
        // We multiply the 'speed' variable to the Rigidbody's velocity...
        // and also multiply 'Time.fixedDeltaTime' to keep the movement consistant on all devices
        playerRigidbody.velocity = direction * playerSpeedCoefficient * Time.fixedDeltaTime;
    }
}
