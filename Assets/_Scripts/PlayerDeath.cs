using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour {
    SpriteRenderer rend;
    GameController gameController;
	// Use this for initialization
	void Start () {
        rend = GetComponentInParent<SpriteRenderer>();
        gameController = FindObjectOfType<GameController>();
        StartCoroutine("FadeOut");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator FadeOut()
    {
        Time.timeScale = 0f;
        
        //float pauseTime = Time.realtimeSinceStartup + 1f;

        
        //while (pauseTime > Time.realtimeSinceStartup )
        //{
            
            for (float f = 2f; f > -0.05f; f -= 0.025f)
            {
                Color c = rend.material.color;
                // 'a' is Alpha channel
                c.a = f;
                rend.material.color = c;
                //yield return new WaitForSeconds(0.05f);
                yield return 0;
            }
        //}
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //Time.timeScale = 1f;
        //yield return new WaitForSeconds(2);
        //Debug.Log("Inside FadeOut");
        gameController.DeadPlayer();

    }
}
