using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseBackground;
    public GameObject inplayUI;

    private SoundController soundController;

    [SerializeField]
    private AudioClip clickClip;

    //private GameController gameController;

    private TimeLeft timeLeft;
    private float initialTime;

    private void Start()
    {
        soundController = SoundController.FindSoundController();
        //gameController = FindObjectOfType<GameController>();

        timeLeft = FindObjectOfType<TimeLeft>();
        //initialTime = timeLeft.timeLeft;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseMenu.GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseBackground.SetActive(false);
        pauseMenuUI.SetActive(false);
        inplayUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        //if (soundController)
        //{
        //    soundController.PlayOneShot(clickClip);
        //    soundController.ResumeMusic();
        //}
    }

    void Pause()
    {
        inplayUI.SetActive(false);
        pauseBackground.SetActive(true);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        if (soundController)
        {
            soundController.PlayOneShot(clickClip);
            soundController.PauseMusic();
        }
    }

    public void Restart()
    {
        //if (soundController)
        //{
        //    soundController.PlayOneShot(clickClip);
        //    soundController.StopMusic();
        //}
        timeLeft.timeLeft = 30f;
        FindObjectOfType<PlayerMovement>().health = 100;
        Lives.PlayerLives = 3;
        ScoreScript.scoreValue = 0;

        FindObjectOfType<InplayUIController>().RestartScene();

        Time.timeScale = 1f;

        SceneManager.LoadScene("Level1");
    }

    public void Exit()
    {
        if (soundController)
        {
            //soundController.PlayOneShot(clickClip);
            soundController.StopMusic();
        }

        timeLeft.timeLeft = 30f;
        FindObjectOfType<PlayerMovement>().health = 100;
        Lives.PlayerLives = 3;
        ScoreScript.scoreValue = 0;
        FindObjectOfType<InplayUIController>().RestartScene();

        Time.timeScale = 1f;
        //gameController.RestartScene();
        SceneManager.LoadScene("Menu");
    }
}
