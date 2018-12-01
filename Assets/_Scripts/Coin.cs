
using UnityEngine;

public class Coin : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag.Equals("Player") )
        {
            ScoreScript.scoreValue += 10;
            Destroy(gameObject);
        }
    }
}
