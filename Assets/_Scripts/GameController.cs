using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public GameObject timeIsUp, restartButton, gameOver;

    public PlayerMovement player;
    public Transform startingPoint;

	// Use this for initialization
	void Start () {
        startingPoint = GameObject.FindGameObjectWithTag("StartingPoint").transform;

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

                gameOver.gameObject.SetActive(true);
                restartButton.gameObject.SetActive(true);

            }
        }
    }

    public void restartScene()
    {
        //Lives.lives -= 1;
        Time.timeScale = 1;
        TimeLeft.timeLeft = 10f;
        HealthBar.healthAmount = 2.5f;

        timeIsUp.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        
        SceneManager.LoadScene("Level1");

    }
}
