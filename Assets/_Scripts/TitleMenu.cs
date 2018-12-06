using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour {
    private SoundController soundController;

    [SerializeField]
    private AudioClip insertCoinClip;

    private void Start()
    {
        soundController = SoundController.FindSoundController();
    }

    public void InsertCoin()
    {
        if (soundController)
        {
            soundController.PlayOneShot(insertCoinClip);
        }

        StartCoroutine("LoadSceneAfterSound");

    }

    IEnumerator LoadSceneAfterSound()
    {
        float pauseTime = Time.realtimeSinceStartup + 1.5f;

        while (Time.realtimeSinceStartup < pauseTime)
        {
            yield return 0;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
