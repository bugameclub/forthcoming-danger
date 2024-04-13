using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20F;
    public Rigidbody2D rb;
    public int damage = 27;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
        Destroy(gameObject, 1.50f);
    }

    void OnCollisionStay2D (Collision2D hitInfo)
    {
        EnemyBehavior enemy = hitInfo.gameObject.GetComponent<EnemyBehavior>();
        SctructureScript Structure = hitInfo.gameObject.GetComponent<SctructureScript>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        if(hitInfo.gameObject.tag == "Structure")
        {
            Structure.TakeDamage(damage);
        }
        
        Destroy(gameObject);
    }


}
