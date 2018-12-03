using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLimit : MonoBehaviour {
    private Vector2 min, max;
    private Rigidbody2D playerRB;
    private float xValue, yValue;

    private void Start()
    {
        //Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        //Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

       if (transform.position.x < 0 )
        {
            min.x = transform.position.x;
            max.x = 0f;
        }
       else
        {
            min.x = 0f;
            max.x = transform.position.x;
        }

       if (transform.position.y < 0)
        {
            min.y = transform.position.y;
            max.y = 0f;
        }
       else
        {
            min.y = 0f;
            max.y = transform.position.y;
        }

        max.y = max.y - 0.360f;
        min.y = min.y + 0.360f;

        max.x = max.x - 0.450f;
        min.x = min.x + 0.450f;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            playerRB = collision.gameObject.GetComponent<PlayerMovement>().GetComponent<Rigidbody2D>();


            xValue = Mathf.Clamp(playerRB.position.x, min.x, max.x);
            yValue = Mathf.Clamp(playerRB.position.x, min.y, max.y);

            playerRB.position = new Vector2(xValue, yValue);

        }
    }
}
