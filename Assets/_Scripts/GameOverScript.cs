using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("GameOverTimeout");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator GameOverTimeout()
    {
        float pauseTime = Time.realtimeSinceStartup + 3f;

        while (pauseTime > Time.realtimeSinceStartup)
        {
            yield return 0;
        }

        //Debug.Log("Inside GameOverTimeout");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");

    }

}
