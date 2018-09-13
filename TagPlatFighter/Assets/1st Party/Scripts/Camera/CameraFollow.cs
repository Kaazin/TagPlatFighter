using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour 
{ 
    [SerializeField] float near, med, far;               //variables for distance between the vectors' maximum for fov change
    [SerializeField] float nearFov, medFov, farFov;     //fov values based on players' distance from each other
    [SerializeField] float distance;                   //variable for the distaence between vectors
    [SerializeField] float fovSpeed;                  //field of view lerp speed multiplier
    Transform p1;                                    //player 1's position
    Transform p2;                                   //player 2's position
    float midZ, midY;                              //the midpoint of p1 and p2's z and y positions  
    public Vector3 pos;                           //the position of the midpoint
    Camera cam;

	// Use this for initialization
	void Awake ()
    {   //set up the references
        p1 = GameObject.FindGameObjectWithTag("p1").transform;
        p2 = GameObject.FindGameObjectWithTag("p2").transform;
        cam = GetComponentInChildren<Camera>();
        midZ = (p1.position.z + p2.position.z) / 2;
        midY = (p1.position.y + p2.position.y) / 2;

        pos = new Vector3(-12, midY + 2, midZ);
    }

    void Update () 
    {
        //assign values to midY and mid Z
        midZ = (p1.position.z + p2.position.z) / 2;
        midY = (p1.position.y + p2.position.y) / 2;

        //assign a value to pos

        //clamp the pos.y to make sure the camera doesn't dirft too far and focus on only one player

        //calculate the distance between players
        distance = Vector3.Distance(p1.position, p2.position);

        if (distance <= near)
        {
            pos = new Vector3(-12, midY + 2, midZ);
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, nearFov, Time.deltaTime * fovSpeed);
        }
        else if (distance > near && distance <= med)
        {
            pos = new Vector3(-12, midY + 2, midZ);
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, medFov, Time.deltaTime * fovSpeed);
        }
        else if (distance > med)
        {
            pos = new Vector3(-12, midY + 2, midZ);
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, farFov, Time.deltaTime * fovSpeed);
        }


        pos.y = Mathf.Clamp(pos.y, -3, 7);


        transform.position = Vector3.Lerp(transform.position,pos, Time.deltaTime * fovSpeed);

    }
}
