using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public static float healthAmount = 1f;
    Vector3 localScale;

	// Use this for initialization
	void Start () {
        localScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        // localScale.x = PlayerMovement.healthAmount;
        localScale.x = healthAmount;
        transform.localScale = localScale;
	}
}
