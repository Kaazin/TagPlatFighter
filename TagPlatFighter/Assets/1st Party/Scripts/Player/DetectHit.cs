using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHit : MonoBehaviour
{
    public bool isPlayer1;
    public float damage;
    void OnTriggerEnter(Collider col)
    {
        if (col.name == "P2_Hurtbox" && isPlayer1)
        {
          
        }
        else if (col.name == "P1_Hurtbox" && !isPlayer1)
        {
            Debug.Log("Hit Player");
        }
    }
}
