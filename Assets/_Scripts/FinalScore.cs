using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour {
    public Text text;

    // Use this for initialization
    void Start () { 
        text = GetComponent<Text>();
        text.text = "Final Score: " + ScoreScript.scoreValue;
        StartCoroutine("WinSceneTimeout");
    }

    IEnumerator WinSceneTimeout()
    {
        float pauseTime = Time.realtimeSinceStartup + 20f;

        while (pauseTime > Time.realtimeSinceStartup)
        {
            yield return 0;
        }

        //Debug.Log("Inside GameOverTimeout");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");

    }
}
