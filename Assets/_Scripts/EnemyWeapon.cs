using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour {

    public Transform firePoint;
    public GameObject enemyBulletPrefab;

    private PlayerMovement player;
    private Enemy enemy;
    private Vector3 enemyDirection;
    private Rigidbody2D enemyRB;

    private void Start()
    {
        //Debug.Log("Inside EnemyWeapon.Start()");
        player = FindObjectOfType<PlayerMovement>();
        enemy = GetComponentInParent<Enemy>();
        enemyRB = enemy.GetComponent<Rigidbody2D>();
        InvokeRepeating("Shoot", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Inside EnemyWeapon.Update()");

        //enemyDirection = transform.InverseTransformDirection(enemyRB.velocity);
        //Debug.Log("enemyDirection: " + enemyDirection);
        //if ((enemyDirection.x > 0 && player.transform.position.x > transform.position.x)
        //    || (enemyDirection.x < 0 && player.transform.position.x < transform.position.x))
        //{
        //    Shoot();
        //}

    }

    void FixUpdate()
    {
        //Debug.Log("Inside EnemyWeapon.FixUpdate()");
        //enemyDirection = transform.InverseTransformDirection(enemyRB.velocity);
        //if ((enemyDirection.x > 0 && player.transform.position.x > transform.position.x)
        //    || (enemyDirection.x < 0 && player.transform.position.x < transform.position.x))
        //{
        //    Shoot();
        //}

    }

    

    void Shoot()
    {
        //Debug.Log("enemyDirection: " + enemyDirection);

        //Vector3 thePosition = firePoint.position;
        //if (!enemy.movingRight && thePosition.x > 0)
        //{
        //    //thePosition.x *= -1;
        //    //firePoint.position = thePosition;
        //    firePoint.Rotate(0f, 180f, 0f);
        //}

        //if (enemy.movingRight && thePosition.x < 0)
        //{
        //    //thePosition.x *= -1;
        //    //firePoint.position = thePosition;
        //    firePoint.Rotate(0f, 180f, 0f);
        //}

        enemyDirection = transform.InverseTransformDirection(enemyRB.velocity);
        
        if ((enemyDirection.x > 0 && player.transform.position.x > transform.position.x)
            || (enemyDirection.x < 0 && player.transform.position.x < transform.position.x))
        {
            Instantiate(enemyBulletPrefab, firePoint.position, firePoint.rotation);
        }

    }
}
