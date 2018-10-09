using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAnimationForce : StateMachineBehaviour {
    public bool y;
    public bool z;
    public float ZForce, YForce;
    public Quaternion rotation;
    public Transform target;
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        rotation = animator.transform.parent.rotation;
        target = GameObject.FindGameObjectWithTag("p2").transform;
    }

	 //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


        animator.GetComponentInParent<PlayerMovement>().dir.y = 0;

        if (stateInfo.normalizedTime <= .15f)
        {

            animator.GetComponentInParent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY;
            //animator.transform.parent.rotation = rotation;
            if (animator.GetComponentInParent<PlayerMovement>().sideB)
                return;

            if (z)
            {
                animator.GetComponentInParent<PlayerMovement>().GetComponent<Rigidbody>().velocity
                    = animator.transform.parent.forward * ZForce;
            }
            else if (y)
            {
                animator.GetComponentInParent<PlayerMovement>().GetComponent<Rigidbody>().velocity
                    = animator.transform.parent.forward * ZForce;

            }
        }
        else if (stateInfo.normalizedTime > .15f)
        {
            animator.GetComponentInParent<PlayerMovement>().GetComponent<Rigidbody>().velocity
                    = Vector3.zero;
            animator.transform.parent.GetComponent<Rigidbody>().collisionDetectionMode =
    CollisionDetectionMode.Discrete;

        }
    }




    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.GetComponentInParent<PlayerMovement>().enabled = true;
  //      animator.transform.parent.rotation = rotation;
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
