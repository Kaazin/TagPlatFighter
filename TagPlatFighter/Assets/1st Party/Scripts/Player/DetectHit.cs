using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHit : MonoBehaviour
{
    public bool isPlayer1;
    public float damage;    //damage per hit
    public float knockback; //knockback per hit
    public float angle;     //angle of knockback
    Vector3 force;
    void OnTriggerEnter(Collider col)
    {
        //if we collide with one of player 2's hurtboxes and we are player one...
        if (col.name == "P2_Hurtbox" && isPlayer1)
        {
            Vector3 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.forward;
            //add that force to the hit player's rigidbody
            col.GetComponentInParent<Rigidbody>().velocity = dir * knockback;
            Debug.Log(dir);
            Debug.DrawLine(col.transform.position, dir * knockback, new Color(255, 0, 255), 100);
            //Debug.Log("hit enemy");
        }
        /*
        else if (col.name == "P1_Hurtbox" && !isPlayer1)
        {
            Debug.Log("Hit Player");
        }
        */
    }
}
