//Kevin Connell STrain 1/07/23 Code

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //combat
    public GameObject BulletPrefab;
    public Transform FirePoint;
    public int health = 100;
    public int money = 0;

    //movement and rotation
    public bool ismoving = true;
    public float speed;
    public float rotSpeed = 5f;
    float angle;
    private Rigidbody2D playerRigid;
    private Vector3 change;
    public Vector2 turn;

    public GameObject enemySpawner;
    private bool isActive;

    private SpriteRenderer spriteRenderer;

    void Start()
    {   
        playerRigid = GetComponent<Rigidbody2D>();
        isActive = enemySpawner.activeSelf;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical"); 
        turn = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Atan2(turn.y, turn.x) * Mathf.Rad2Deg;
        
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;

        MoveChar(speed);


        if(Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
        if (Input.GetKeyDown("z"))
        {
            print("Z Pressed");
            isActive = !isActive;
            enemySpawner.SetActive(isActive);
        }
    }

    void shoot()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
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
        Destroy (gameObject);
    }

    void MoveChar(float speed)
    {
        playerRigid.MovePosition(transform.position + change * speed * Time.deltaTime); 
    }

    public void addMoney()
    {
        money += 10;
    }

    public IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(.1f);
        spriteRenderer.color = Color.white;
    }

}

