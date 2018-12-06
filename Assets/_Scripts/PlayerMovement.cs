using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMortal
{

    public CharacterController2D controller;
    public float runSpeed = 40f;
    public int health = 100;
    //public static int lives = 3;

    private InplayUIController inplayUIController;
    //private GameController gameController;
    //private SpriteRenderer rend;
    private SoundController soundController;

    [SerializeField]
    private AudioClip jumpClip;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    private void Start()
    {
        inplayUIController = FindObjectOfType<InplayUIController>();
        //gameController = FindObjectOfType<GameController>();
        //rend = GetComponent<SpriteRenderer>();
        //StartCoroutine("FadeOut");
        soundController = FindObjectOfType<SoundController>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            if (soundController)
            {
                soundController.PlayOneShot(jumpClip);
            }

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
        GetComponent<PlayerDeath>().enabled = true;

        //gameController.DeadPlayer();
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

    //IEnumerator FadeOut()
    //{
    //    Time.timeScale = 0f;

    //    for (float f = 1; f > -0.05f; f -= 0.05f)
    //    {
    //        Color c = rend.material.color;
    //        // 'a' is Alpha channel
    //        c.a = f;
    //        rend.material.color = c;
    //        yield return new WaitForSeconds(0.05f);
    //    }
    //}

}