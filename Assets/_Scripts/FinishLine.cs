using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour {
    private GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            gameController.LevelCompleted();
        }
    }
}
