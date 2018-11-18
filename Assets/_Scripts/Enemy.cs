using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int health = 100;
    public float moveSpeed = 2f;
    Vector3 localScale;
    private bool movingRight;
    Rigidbody2D rb;

    public void TakeDamage(int damage)
    {
        //Debug.Log("damage taken");

        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Death effects go here
        
        Destroy(gameObject);
    }

	// Use this for initialization
	void Start () {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        movingRight = true;
        localScale.x = 1;
        transform.localScale = localScale;
        rb.velocity = new Vector2(localScale.x * moveSpeed, rb.velocity.y);
    }
	
	// Update is called once per frame
	//void Update () {
        //if (movingRight)
        //{
        //    moveRight();
        //}
        //else
        //{
        //    moveLeft();
        //}
    //}

    void moveRight()
    {
        //Debug.Log("Inside enemy's moveRight");
        movingRight = true;
        localScale.x = 1;
        transform.localScale = localScale;
        rb.velocity = new Vector2(localScale.x * moveSpeed, rb.velocity.y);
    }

    void moveLeft()
    {
        //Debug.Log("Inside enemy's moveLeft");
        movingRight = false;
        localScale.x = -1;
        transform.localScale = localScale;
        rb.velocity = new Vector2(localScale.x * moveSpeed, rb.velocity.y);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log(collision.otherCollider.name);
    //PlayerMovement player = collision.otherCollider.GetComponent<PlayerMovement>();

    //if ( player == null )
    //{
    //    movingRight = !movingRight;
    //}

    //    if ( collision.gameObject.tag.Equals("Player") )
    //    {
    //        movingRight = !movingRight;

    //        transform.Rotate(0f, 180f, 0f);
    //    }

    //}

    public void ChangeDirection()
    {
        //Debug.Log("Inside enemy's change direction");
        transform.Rotate(0f, 180f, 0f);

        if (movingRight)
        {
            moveLeft();
        }
        else
        {
            moveRight();
        }
    }


}
