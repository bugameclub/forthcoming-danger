//Kevin Connell STrain 1/07/23 Code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SctructureScript : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int maxHealth=100;

    public KeyCode toggleKey = KeyCode.E;
    private SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void TakeDamage(int damage)
    {
        health = health - damage;

        if (health <= 0)
            die();
    }

    void die()
    {
        Destroy (gameObject);
        AstarPath.active.Scan();
    }

    /*public void StateChange(bool input)
    {
        gameObject.SetActive(input);
    }*/

void OnTriggerStay2D(Collider2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        if (Input.GetKeyDown(toggleKey))
        {
            print("E happened");

            if (gameObject.layer == LayerMask.NameToLayer("Window"))
            {
                gameObject.layer = LayerMask.NameToLayer("OpenWindow");
                spriteRenderer.enabled = !spriteRenderer.enabled;
                GetComponent<BoxCollider2D> ().enabled = false;
                //print("Window Opened");
            }
            else if(gameObject.layer == LayerMask.NameToLayer("OpenWindow"))
            {
                gameObject.layer = LayerMask.NameToLayer("Window");
                spriteRenderer.enabled = !spriteRenderer.enabled;
                GetComponent<BoxCollider2D> ().enabled = true;
                //print("Window Closed");
            }
        }
    }
}
}
