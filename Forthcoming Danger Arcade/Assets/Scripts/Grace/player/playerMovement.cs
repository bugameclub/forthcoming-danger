using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    public float playerSpeedCoefficient; // effects the movement speed of the player
    public Camera cam1; // the main camera, used for player position determination

    void Start()
    {
        
    }

    void Update()
    {
        moveCheck();
        rotateCheck();
    }

    public void moveCheck()
    {
        // checks key presses and adds corresponding velocity vector:

        if (Input.GetKeyDown(KeyCode.D))
        {
            playerRigidbody.velocity += Vector2.right * playerSpeedCoefficient;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            playerRigidbody.velocity += Vector2.left * playerSpeedCoefficient;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            playerRigidbody.velocity += Vector2.up * playerSpeedCoefficient;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerRigidbody.velocity += Vector2.down * playerSpeedCoefficient;
        }

        // checks key releases and subtracts corresponding velocity vector:

        if (Input.GetKeyUp(KeyCode.D))
        {
            playerRigidbody.velocity -= Vector2.right * playerSpeedCoefficient;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            playerRigidbody.velocity -= Vector2.left * playerSpeedCoefficient;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            playerRigidbody.velocity -= Vector2.up * playerSpeedCoefficient;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            playerRigidbody.velocity -= Vector2.down * playerSpeedCoefficient;
        }
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
}
