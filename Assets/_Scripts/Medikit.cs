using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medikit : MonoBehaviour {
    private GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
        
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag.Equals("Player"))
    //    {
    //        gameController.HealthBoost(this);
    //        //Destroy(gameObject);
    //    }
    //}

    public void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("Inside Medikit trigger");
        if (other.gameObject.tag.Equals("Player"))
        {
            //Debug.Log("Inside Medikit trigger tag Player");
            gameController.HealthBoost(this);
        }
    }

    
}
