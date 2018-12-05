using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public int scoreValue = 0;
    public Text text;

    public int Score
    {
        get { return scoreValue; }
        set { scoreValue = value;
            text.text = "Score: " + scoreValue;
        }
    }

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        text.text = "Score: " + scoreValue;
    }
	
	// Update is called once per frame
	//void Update () {
        //text.text = "Score: " + scoreValue;
	//}
}
