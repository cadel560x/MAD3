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
        player = FindObjectOfType<PlayerMovement>();
        enemy = GetComponentInParent<Enemy>();
        enemyRB = enemy.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixUpdate()
    {
        if (enemyDirection.x == 1)
        {
            Shoot();
        }
    }

    private void Update()
    {
        enemyDirection = transform.InverseTransformDirection(enemyRB.velocity);

    }

    void Shoot()
    {
        Instantiate(enemyBulletPrefab, firePoint.position, firePoint.rotation);
    }
}
