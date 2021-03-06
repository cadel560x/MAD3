﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;

    private Enemy enemy;

    // Use this for initialization
    void Start () {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.name);
        enemy = collision.GetComponent<Enemy>();

        if ( enemy != null )
        {
            enemy.TakeDamage(damage);

            Destroy(gameObject);
        }
        
    }

    //private void Update()
    //{
        //Destroy(gameObject, 2f);
    //}

}
