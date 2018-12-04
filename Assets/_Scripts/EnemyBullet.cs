using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;

    private PlayerMovement player;

    // Use this for initialization
    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.name);
        player = collision.GetComponent<PlayerMovement>();

        if (player != null)
        {
            player.TakeDamage(damage);

            Destroy(gameObject);
        }

    }
}
