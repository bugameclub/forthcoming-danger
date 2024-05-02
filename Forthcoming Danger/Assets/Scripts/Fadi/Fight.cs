using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    // Start is called before the first frame update
	ParticleSystem ps;
	List<ParticleCollisionEvent> collisionEvents;
	bool trigger;
	public bool multi;
	public bool auto;
	public float wait = 2f;
	float timer = 0f;
	//public string shootButton = "mouse 0";

    void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
		collisionEvents = new List<ParticleCollisionEvent>();
    }

    // Update is called once per frame
    void Update()
    {
		timer += Time.deltaTime;
        if(Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.T) || Input.GetKey(KeyCode.G) || Input.GetKey(KeyCode.H))
        {
			//ps.enableEmission = true;
			trigger = true;
			if(multi && timer > wait){
				ps.Emit(10);
				timer = 0;
				//Time.timeScale = 0.4f;
			}
		}
		else
		{
			trigger = false;
		}
		if(trigger && !multi && timer > wait){
			timer = 0;
			ps.Emit(1);
			//Time.timeScale = 0.4f;
		}

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
                if(other.tag == "Enemy"){
					other.GetComponent<enemyLife>().health--;
					Debug.Log("HIT");
				}
            }
            i++;
        }
    }
}
