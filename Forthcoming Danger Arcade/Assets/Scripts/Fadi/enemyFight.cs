using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFight : MonoBehaviour
{
	public int damage = 3;
    ParticleSystem ps;
	List<ParticleCollisionEvent> collisionEvents;
    void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
		collisionEvents = new List<ParticleCollisionEvent>();
    }
	void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = ps.GetCollisionEvents(other, collisionEvents);

        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        int i = 0;

        while (i < numCollisionEvents)
        {
            if (rb)
            {
                if(other.tag == "Player"){
					other.GetComponent<collidablePlayerMovement>().health -= damage;
					Debug.Log("HIT");
				}
            }
            i++;
        }
    }
}
