using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setRot : StateMachineBehaviour {

    public Transform player;
    public Quaternion currentRot;
    public Vector3 rot;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.gameObject.transform;
        //Debug.Log(player.name);
        currentRot = player.rotation;
        //Debug.Log("ResetRot");
        rot = currentRot.eulerAngles;
        Debug.Log(rot);
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	if(stateInfo.normalizedTime >= 0.99f)
        {
            animator.transform.rotation = Quaternion.Euler(rot);
            Debug.Log(rot);
        }
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
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
