using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLife : MonoBehaviour
{
    public GameObject player;
	public int health = 30;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 1){
            player.GetComponent<collidablePlayerMovement>().fscore += 50.0f;
            Destroy(gameObject);
		}
    }
}
