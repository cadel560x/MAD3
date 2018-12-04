using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour {
    static Text text;
    public static int lives = 3;
    //private static GameController gameController;

    public static int PlayerLives {
        get { return lives; }
        set { lives = value;
            //if (lives < 1)
            //{
            //    gameController.GameOver();
            //}
            //else
            //{
            //    gameController.RestartScene();
            //}

            text.text = "x " + lives;
        }
    }

    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
        text.text = "x " + lives;

        //gameController = FindObjectOfType<GameController>();
    }
	
	// Update is called once per frame
	//void Update () {
        // text.text = "x " + lives;
    //}
}
