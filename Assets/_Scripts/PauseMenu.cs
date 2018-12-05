using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseBackground;
    public GameObject inplayUI;

    private void Start()
    {
        
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
    }

    void Pause()
    {
        inplayUI.SetActive(false);
        pauseBackground.SetActive(true);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        TimeLeft.timeLeft = 30f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        //Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
