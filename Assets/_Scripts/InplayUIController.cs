using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InplayUIController : MonoBehaviour {
    public GameObject timeIsUp, restartButton, gameOver, health, lives;

    public PlayerMovement player;
    public Transform startingPoint;
    private HealthBar healthBar;

    // Use this for initialization
    void Start () {
        startingPoint = GameObject.FindGameObjectWithTag("StartingPoint").transform;
        // HealthBar healthBar = GameObject.FindObjectOfType<HealthBar>();
        healthBar = health.GetComponentInChildren<HealthBar>();
        //Debug.Log(healthBar);

    }

    // Update is called once per frame
    void Update () {
		if ( TimeLeft.timeLeft <= 0 )
        {
            Time.timeScale = 0;
            timeIsUp.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            Lives.lives -= 1;
        }
	}

    private void FixedUpdate()
    {
        if ( player.transform.position.y <= -4)
        {
            if ( Lives.lives > 1 )
            {
                Time.timeScale = 0;
                Lives.lives -= 1;
                // player.transform.position = startingPoint.transform.position;
                restartScene();
            } else
            {
                // Game over
                Time.timeScale = 0;
                player.gameObject.SetActive(false);
                health.gameObject.SetActive(false);
                lives.gameObject.SetActive(false);

                gameOver.gameObject.SetActive(true);
                restartButton.gameObject.SetActive(true);

            }
        }
    }

    public void restartScene()
    {
        //Lives.lives -= 1;
        Time.timeScale = 1;
        TimeLeft.timeLeft = 30f;
        //HealthBar.healthAmount = 1f;
        healthBar.healthAmount = 1f;

        timeIsUp.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        
        SceneManager.LoadScene("Level1");

    }

    public void updateHealth()
    {
        //HealthBar.healthAmount -= 0.1f;

        healthBar.updateHealth();
    }
}
