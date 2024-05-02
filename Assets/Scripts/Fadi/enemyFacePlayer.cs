using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class enemyFacePlayer : MonoBehaviour
{
	bool playerFound;
	public AIPath aipath;
	Vector2 direction;
	Vector2 playerPosition;
	public GameObject weapon;
    void Update()
    {
        faceVelocity();
    }
	void faceVelocity()
	{
		if(!playerFound)
		{
			direction = aipath.desiredVelocity;
			transform.up = direction * -1.0f;
		}
		
	}
	
	void FixedUpdate()
	{
		bool foundNow = false;
		playerPosition = GameObject.Find("player").transform.position;
		RaycastHit2D hit = Physics2D.Raycast(this.gameObject.transform.position, playerPosition - new Vector2(transform.position.x,transform.position.y));
        //If something was hit.
        if (hit.collider != null)
        {
			if(hit.collider.name == "player"){
				playerFound = true;
				foundNow = true;
				
				direction = hit.collider.transform.position- transform.position;
				transform.up = direction * -1.0f;
				aipath.enableRotation = false;
				weapon.SetActive(true);
			}
            //Display the point in world space where the ray hit the collider's surface.
        }
		if(!foundNow){
			playerFound = false;
			aipath.enableRotation = true;
			weapon.SetActive(false);
		}
	}
}
