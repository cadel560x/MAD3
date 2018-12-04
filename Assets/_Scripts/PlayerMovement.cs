using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMortal
{

    public CharacterController2D controller;
    public float runSpeed = 40f;

    private InplayUIController inplayUIController;
    private GameController gameController;

    public int health = 100;
    //public static int lives = 3;

    

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    private void Start()
    {
        inplayUIController = FindObjectOfType<InplayUIController>();
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        //if ( HealthBar.healthAmount <= 0 )
        //{
        //    Destroy(gameObject);
        //}

    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag.Equals("Enemy"))
    //    {
            //Collider2D enemyCollider = collision.gameObject.GetComponent<Collider2D>();
            //if (enemyCollider.name.Equals("bodyCollider")) {
                //HealthBar.healthAmount -= 0.1f;
                //inplayUIController.updateHealth();
                //TakeDamage(10);

                //Debug.Log(healthAmount);
            //}
    //    }
    //}

    public void Die()
    {
        // Death effects go here
        // Fade out
        gameController.DeadPlayer();
        //Destroy(gameObject);

        // Stop everything, freeze scene
        //Lives.PlayerLives -= 1;
    }

    public void TakeDamage(int damage)
    {
        health -= (damage);
        if (health <= 0)
        {
            Die();
        }

        inplayUIController.UpdateHealthBar(damage);
    }

}