using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLeft : MonoBehaviour {
    //public static float timeLeft;
    public float timeLeft;


    Text text;
    private GameController gameController;

    // Use this for initialization
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            timeLeft = 0;
            gameController.TimesUp();
        }

        text.text = "Time: " + Mathf.Round(timeLeft);

    }
}
