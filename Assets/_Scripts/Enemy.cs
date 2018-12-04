using UnityEngine;

public class Enemy : MonoBehaviour, IMortal {
    public int health = 100;
    public int damage = 40;
    public float moveSpeed = 2f;
    private Vector3 localScale;
    public bool movingRight;
    private Rigidbody2D rb;

    //[SerializeField]
    //private Collider2D headCollider;
    //[SerializeField]
    //private Collider2D bodyCollider;


    public void TakeDamage(int damage)
    {
        //Debug.Log("damage taken");

        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // Death effects go here
        
        Destroy(gameObject);
    }

	// Use this for initialization
	void Start () {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        if (movingRight)
        {
            localScale.x = 1;
        }
        else
        {
            localScale.x = -1;
        }
        //localScale.x = 1;
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

    private void moveRight()
    {
        //Debug.Log("Inside enemy's moveRight");
        movingRight = true;
        localScale.x = 1;
        transform.localScale = localScale;
        rb.velocity = new Vector2(localScale.x * moveSpeed, rb.velocity.y);
    }

    private void moveLeft()
    {
        //Debug.Log("Inside enemy's moveLeft");
        movingRight = false;
        localScale.x = -1;
        transform.localScale = localScale;
        rb.velocity = new Vector2(localScale.x * moveSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.otherCollider.name);
        //PlayerMovement player = collision.otherCollider.GetComponent<PlayerMovement>();

        //if (player == null)
        //{
        //    movingRight = !movingRight;
        //}

        //if (collision.gameObject.tag.Equals("Player"))
        //{
        //    movingRight = !movingRight;

        //    transform.Rotate(0f, 180f, 0f);
        //}

        if (collision.gameObject.tag.Equals("Player"))
        {
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            player.TakeDamage(10);
        }


    }

    public void ChangeDirection()
    {
        Debug.Log("Inside enemy's change direction, "+ gameObject.name);
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
