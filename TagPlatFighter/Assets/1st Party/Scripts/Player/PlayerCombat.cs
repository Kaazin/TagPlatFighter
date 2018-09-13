using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Animator anim;          //the animator attached the player

    public float resetTime;
	void Awake () 
    {
        anim = GetComponent<Animator>();
	}
	
	void Update () 
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetBool("Attack", true);
            StartCoroutine(ResetAttack());
        }
    }

    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(resetTime);
        anim.SetBool("Attack", false);
    }
}
