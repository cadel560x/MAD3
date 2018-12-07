using UnityEngine;

public class InplayUIController : MonoBehaviour {
    public GameObject timeIsUp, gameOver, health, lives, levelCompleted, inplayUI;

    public PlayerMovement player;
    
    private HealthBar healthBar;

    // Use this for initialization
    void Start () {
        
        // HealthBar healthBar = GameObject.FindObjectOfType<HealthBar>();
        healthBar = health.GetComponentInChildren<HealthBar>();
        //Debug.Log(healthBar);

    }

    public void LevelCompleted()
    {
        levelCompleted.SetActive(true);
    }

    // Update is called once per frame
    //void Update () {
        //Time.timeScale = 0;
        //Lives.lives -= 1;
	//}

    //private void FixedUpdate()
    //{
    //    //if ( player.transform.position.y <= -4)
    //    //{
    //        // Out to GameController
    //        if ( Lives.lives > 1 )
    //        {
    //            Time.timeScale = 0;
    //            Lives.lives -= 1;
    //            // player.transform.position = startingPoint.transform.position;
    //            restartScene();
    //        } else
    //        {
    //            // Game over
    //            Time.timeScale = 0;
    //            player.gameObject.SetActive(false);
    //            health.gameObject.SetActive(false);
    //            lives.gameObject.SetActive(false);

    //            gameOver.gameObject.SetActive(true);
    //            restartButton.gameObject.SetActive(true);

    //        }
    //    //}
    //}

    // Out to a GameController
    
    
    public void UpdateHealthBar(int amount)
    {
        //HealthBar.healthAmount -= 0.1f;

        healthBar.UpdateHealth(amount);
    }

    public void ResetHealtBar()
    {
        //Debug.Log("Inside ResetHealtBar");
        healthBar.ResetHealthBar();
    }

    public void RestartScene()
    {
        timeIsUp.gameObject.SetActive(false);
        //restartButton.gameObject.SetActive(false);

        healthBar.ResetHealthBar();
    }

    public void TimesUp()
    {
        timeIsUp.gameObject.SetActive(true);
        //restartButton.gameObject.SetActive(true);
    }

    //public void StartTimer()
    //{
        //timeIsUp.gameObject.SetActive(false);
        //restartButton.gameObject.SetActive(false);
    //}

    public void GameOver()
    {
        //player.gameObject.SetActive(false);
        //health.gameObject.SetActive(false);
        //lives.gameObject.SetActive(false);
        gameOver.SetActive(true);
        healthBar.ResetHealthBar();
        inplayUI.SetActive(false);

        //Debug.Log("Inside GameOver " + Time.timeScale);
        
        
        //restartButton.gameObject.SetActive(true);
    }
}
