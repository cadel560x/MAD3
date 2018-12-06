using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomp : MonoBehaviour {
    private Enemy enemy;
    private Vector3 enemyScale;
    private Rigidbody2D enemyRB;

    public GameObject feet;

    private SoundController soundController;

    [SerializeField]
    private AudioClip stompClip;

    void Start()
    {
        enemy = GetComponentInParent<Enemy>();
        enemyScale = enemy.transform.localScale;
        enemyRB = enemy.GetComponent<Rigidbody2D>();

        soundController = FindObjectOfType<SoundController>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {   
            enemyRB.velocity = Vector3.zero;
            enemyRB.angularVelocity = 0f;

            enemyScale.y /= 2;
            //enemyScale.z -= 1;
            enemy.transform.localScale = enemyScale;

            enemy.transform.position = feet.transform.position;
            GetComponent<BoxCollider2D>().enabled = false;
            enemy.GetComponent<PolygonCollider2D>().enabled = false;

            if (soundController)
            {
                soundController.PlayOneShot(jumpClip);
            }

            StartCoroutine(EnemySquished(2));
        }
    }

    IEnumerator EnemySquished(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        enemy.Die();
    }

}
