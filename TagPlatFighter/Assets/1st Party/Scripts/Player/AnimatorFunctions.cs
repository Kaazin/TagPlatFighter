﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFunctions : MonoBehaviour 
{
    PlayerMovement playerMovment;
	void Awake () 
    {
        playerMovment = GetComponentInParent<PlayerMovement>();

    }

    public void Jump()
    {
        playerMovment.Jump();
        playerMovment.jumpsLeft--;
    }
    public void DoubleJump()
    {
        playerMovment.DoubleJump();
        playerMovment.jumpsLeft--;
     }

    public void ResetJump()
    {
        playerMovment.anim.SetBool("Jump", false);
    }
    public void ResetLand()
    {
        playerMovment.anim.SetBool("Land", false);
        playerMovment.dir.y = 0;
    }

    public void EnabRootMotion()
    {
        playerMovment.anim.applyRootMotion = true;
    }
    public void DisabRootMotion()
    {
        playerMovment.anim.applyRootMotion = false;
    }

}