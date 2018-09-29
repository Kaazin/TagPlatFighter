using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PercentageCounter : MonoBehaviour
{
    float startingPercentage, currentPercentage; //the starting percentage and current percentage of the player
    Rigidbody rb;                                //the rigidbody attached to the player

 

    // Use this for initialization
    void Awake ()
    {
        currentPercentage = startingPercentage;
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void TakeDamage(float damage)
    {
        currentPercentage += damage;

    }
}
