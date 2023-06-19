//Kevin Connell STrain 1/07/23 Code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehavior : MonoBehaviour
{

    public int health = 100;
    public GameObject player;
    public float speed;
    public int damage = 25;
    [SerializeField] private float attackSpeed = 1f;
    private float canAttack;
    private SpriteRenderer spriteRenderer;



    void Start()
    {
        player = GameObject.FindWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }


    void OnCollisionStay2D (Collision2D hitInfo)
    {
        PlayerScript Player = hitInfo.gameObject.GetComponent<PlayerScript>();
        SctructureScript Structure = hitInfo.gameObject.GetComponent<SctructureScript>();
        if (attackSpeed <= canAttack)
        {
            if (Player != null)
            {
                Player.TakeDamage(damage);
                canAttack = 0f;
            }
            if(hitInfo.gameObject.tag == "Structure")
            {
                Structure.TakeDamage(damage);
                canAttack = 0f;
            }
            if(hitInfo.gameObject.tag == "Window")
            {
                Structure.TakeDamage(damage);
                canAttack = 0f;
            }
            canAttack = 0f;
        }
        else
        {
            canAttack += Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;

        StartCoroutine(FlashRed());

        if (health <= 0)
            die();
    }

    void die()
    {
        GameObject spawner = GameObject.Find("EnemySpawner");
        spawner.GetComponent<EnemySpawner>().OnEnemyDeath();
        Destroy (gameObject);

    }

    public IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(.1f);
        spriteRenderer.color = Color.green;
    }



}
//