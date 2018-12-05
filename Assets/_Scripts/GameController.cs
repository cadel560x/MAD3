using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public Transform startingPoint;

    private InplayUIController inplayUIController;
    private PlayerMovement player;

    // Use this for initialization
    void Start () {
        startingPoint = GameObject.FindGameObjectWithTag("StartingPoint").transform;
        inplayUIController = FindObjectOfType<InplayUIController>();
        player = FindObjectOfType<PlayerMovement>();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void FixedUpdate()
    {
        //if ( player.transform.position.y <= -4)
        //{
        // Out to GameController
        //if (Lives.lives > 1)
        //{
        //    Time.timeScale = 0;
        //    Lives.lives -= 1;
            // player.transform.position = startingPoint.transform.position;
            //RestartScene();
        //}
        //else
        //{
            // Game over
            //Time.timeScale = 0;
            //player.gameObject.SetActive(false);
            //health.gameObject.SetActive(false);
            //lives.gameObject.SetActive(false);

            //gameOver.gameObject.SetActive(true);
            //restartButton.gameObject.SetActive(true);

        //}
        //}
    }

    public void LevelCompleted()
    {
        Time.timeScale = 0;
        inplayUIController.LevelCompleted();
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartScene()
    {
        //StartCoroutine(SuspendTimeScale(5));
        //Lives.lives -= 1;
        //Time.timeScale = 1;
        TimeLeft.timeLeft = 30f;
        //HealthBar.healthAmount = 1f;
        //healthBar.healthAmount = 1f;
        player.health = 100;

        inplayUIController.RestartScene();

        //timeIsUp.gameObject.SetActive(false);
        //restartButton.gameObject.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //Debug.Log("Inside RestartScene");
        Time.timeScale = 1f;
    }

    public void DeadPlayer()
    {
        //Time.timeScale = 0;
        //System.Threading.Thread.Sleep(2000);
        //StartCoroutine("SuspendTimeScale");

        //Lives.lives -= 1;
        //if ( Lives.lives < 1 )
        Lives.PlayerLives -= 1;
        if (Lives.PlayerLives < 1)
        {
            GameOver();
        }
        else
        {
            RestartScene();
        }
    }

    public void TimesUp()
    {
        //Time.timeScale = 0;
        inplayUIController.TimesUp();
        //DeadPlayer();
        player.GetComponent<PlayerDeath>().enabled = true;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        inplayUIController.GameOver();
    }

    public void HealthBoost(Medikit medikit)
    {
        if (player.health < 100)
        {
            player.health = 100;
            inplayUIController.ResetHealtBar();
            Destroy(medikit.gameObject);
        }
    }

    //IEnumerator SuspendTimeScale()
    //{
    //    Time.timeScale = 0f;
    //    float pauseTime = Time.realtimeSinceStartup + 4f;
    //    while (Time.realtimeSinceStartup <  pauseTime)
    //    {
    //        yield return 0;
    //    }

    //    Time.timeScale = 1f;
    //}

}
