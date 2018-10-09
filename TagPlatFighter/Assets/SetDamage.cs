using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDamage : StateMachineBehaviour {
    public float[] StartingDmg, knockback,angle;
    // amount of frames before the late hitbox/total anaimtion frames
    public int numBoxes;
    public BoxCollider[] hitboxes;         //the hitboxes associated with this animation
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        for (int i = 0; i < numBoxes; i++)
        {
            hitboxes = animator.transform.GetComponentsInChildren<BoxCollider>();

            hitboxes[i].GetComponent<DetectHit>().damage = StartingDmg[i];
            hitboxes[i].GetComponent<DetectHit>().knockback = knockback[i];
            hitboxes[i].GetComponent<DetectHit>().angle = angle[i];
            //Debug.Log("hitbox:" + i);
                
        }
        
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
