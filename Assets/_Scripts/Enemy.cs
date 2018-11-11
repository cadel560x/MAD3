using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int health = 100;

    public void TakeDamage(int damage)
    {
        //Debug.Log("damage taken");

        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Death effects go here
        
        Destroy(gameObject);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
