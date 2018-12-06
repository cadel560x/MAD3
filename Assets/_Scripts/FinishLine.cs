using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour {
    private GameController gameController;

    private SoundController soundController;

    [SerializeField]
    private AudioClip levelCompletedClip;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
        soundController = FindObjectOfType<SoundController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (soundController)
            {
                soundController.PlayOneShot(levelCompletedClip);
            }

            gameController.LevelCompleted();
        }
    }
}
