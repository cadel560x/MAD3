
using UnityEngine;

public class Coin : MonoBehaviour {
    public int value;

    private ScoreScript scoreScript;

    private SoundController soundController;

    [SerializeField]
    private AudioClip coinClip;

    private void Start()
    {
        scoreScript = FindObjectOfType<ScoreScript>();

        soundController = SoundController.FindSoundController();
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
            scoreScript.Score += value;

            if (soundController)
            {
                soundController.PlayOneShot(coinClip);
            }

            Destroy(gameObject);
        }

        
    }
}
