using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDamage : StateMachineBehaviour {
    public float[] StartingDmg;
    public float[] lateDmg;
    public float startingHitboxDuration;    //set this equal to
                                            // amount of frames before the late hitbox/total anaimtion frames

    public BoxCollider[] hitboxes;         //the hitboxes associated with this animation
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        
        for (int i = 0; i < StartingDmg.Length; i++)
        {
            hitboxes[i].GetComponent<DetectHit>().damage = StartingDmg[i];
        }
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	if(stateInfo.normalizedTime >= startingHitboxDuration)
        {
            for (int i = 0; i < StartingDmg.Length; i++)
            {
                hitboxes[i].GetComponent<DetectHit>().damage = lateDmg[i];
            }

        }
    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
