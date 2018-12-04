using UnityEngine;

public class Waypoint : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.CompareTag("Enemy") )
        {
            Debug.Log(collision.gameObject.name);
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.ChangeDirection();
        }
    }

}
