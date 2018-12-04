
using UnityEngine;

public class Coin : MonoBehaviour {
    private ScoreScript scoreScript;

    private void Start()
    {
        scoreScript = FindObjectOfType<ScoreScript>();
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if ( collision.gameObject.tag.Equals("Player") )
    //    {
    //        //ScoreScript.scoreValue += 10;
    //        scoreScript.Score += 10;
    //        Destroy(gameObject);
    //    }
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            scoreScript.Score += 10;
            Destroy(gameObject);
        }
    }
}
