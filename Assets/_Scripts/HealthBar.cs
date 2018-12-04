using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    //public float healthAmount = 1f;
    private Vector3 localScale;
    private Vector3 originalTransform;

	// Use this for initialization
	void Start () {
        originalTransform = transform.localScale;
        localScale = transform.localScale;
	}
	
	// Update is called once per frame
	//void Update () {
        // localScale.x = PlayerMovement.healthAmount;
        //localScale.x = healthAmount;
        //transform.localScale = localScale;
	//}

    public void UpdateHealth(int amount)
    {
        //PlayerMovement player = FindObjectOfType<PlayerMovement>();

        //player.healthAmount -= 0.1f;
        float factor = amount / 100f;
        //localScale.x = player.healthAmount;
        localScale.x -= factor;
        transform.localScale = localScale;

        if (localScale.x > 0)
        {
            // Player dies
            // Destroy(gameObject);
            transform.localScale = localScale;
            //player.Die();
        }
    }

    public void ResetHealthBar()
    {
        Debug.Log("Inside HelthBar.ResteHealthBar");
        transform.localScale = originalTransform;
    }

}
