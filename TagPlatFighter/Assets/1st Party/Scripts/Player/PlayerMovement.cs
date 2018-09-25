using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed, airdashSpeed;                        //the speed of the player
    public float moveV, moveH;                              //movmeent directions fo the player                  
    [SerializeField] float maxJumpsLeft = 2, maxAirdashesLeft = 2;   //the maximum amount of jumps and airdashes the player has left
    public bool grounded, goingThruPlat;                  //temp variable to show the state of isgrounded in the inspector
    [SerializeField] Vector3 offset;                              //offset of the death particle FX
    [SerializeField] Transform ltRaycastPoint, rtRaycastPoint;   //points to start raycasts from
    [SerializeField] GameObject deathFX;                         //death particle FX

    int platform, floor;                                          //platform and floor layermasks
    float distToGround;                                            //the distance of the isgrounded check
    Rigidbody rb;                                                   //the rigidbody attached to the player  

    public float jumpSpeed, doubleJumpSpeeed, gravity, fallspeed;                    //the speed of the player's jump, the base gravity of the character, and how much faster he should fall
    public Vector3 dir;                                            //the direction of movement of the player
    public float jumpsLeft, airdashesLeft;                        //the amount of jumps and airdashes the player has by defulat
    public Animator anim;                                        //animator attacehd to the player
    public Character character;
    public Quaternion groundedRot;
    public Transform mesh;
    public Vector3 groundedrot;
    public string input;
    void Awake () 
    {
        //assign variables their default values
        rb = GetComponent<Rigidbody>();
        gravity *= character.fallSpeed;
        distToGround = GetComponent<BoxCollider>().bounds.extents.y;
        jumpsLeft = character.maxJumps;
        airdashesLeft = character.maxAirdashes;
        doubleJumpSpeeed = character.doubleJumpSpeed;
        jumpSpeed = character.jumpSpeed;
        platform = LayerMask.GetMask("Platform");
        platform = LayerMask.GetMask("Platform");
        floor = LayerMask.GetMask("Floor");
        anim = GetComponentInChildren<Animator>();
        speed = character.groundSpeed;
	}
	
	void Update ()
    {

        Vector3 lookDir;

        groundedrot = groundedRot.eulerAngles;
       // Debug.Log(isGrounded());
        anim.transform.localPosition = Vector3.zero;

        //show the state of isGrounded by assigning it to a public variable

        //assign values to moveV and moveH based on directional input from teh player
         moveH = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
         moveV = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        //if the player is grounded and we are moving in a horizontal direction
        if (moveH != 0 && isGrounded() )
        {
            //look in our direction of movement
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(dir.x,0,dir.z)), 1);
            anim.SetBool("Walk", true);
        }
        else
            anim.SetBool("Walk", false);

        //assign a value to dir
        dir = new Vector3(0, dir.y, -moveH);


        //if we are not grounded
        if(!isGrounded())
        {
            anim.SetBool("Land", false);
            speed = character.airSpeed;
            //apply gravity
                dir.y -= gravity * Time.deltaTime;

            if (jumpsLeft >= maxJumpsLeft)
                jumpsLeft = maxJumpsLeft - 1;
        }

        if(isGrounded() && !goingThruPlat)
        {
            //Debug.Log(69);

            //if we are grounded
            //apply no gravity and reset our dir.y back to zero
            //refresh the player's jumps and airdashes

            //if we have landed 
            if (!grounded)
            {
                //Debug.Log(69);
                dir.y = 0;

                anim.SetBool("Jump",  false);
                anim.SetBool("Land", true);
                mesh.transform.rotation = groundedRot;
            }
            speed = character.groundSpeed;
            jumpsLeft = maxJumpsLeft;
            airdashesLeft = maxAirdashesLeft;
        }

        if(!isGrounded())
        {
            if(grounded)
            {
                transform.rotation = groundedRot;
            }
        }
        grounded = isGrounded();

        //if we press the jump key and are either grounded or have at least 1 jumpleft
        if (Input.GetButtonDown("Jump") && (isGrounded() || (jumpsLeft > 0 && jumpsLeft >= maxJumpsLeft)))
        {
            //Jump();
            anim.SetBool("Jump", true);
        }
        if (Input.GetButtonDown("Jump") && (!isGrounded() || (jumpsLeft > 0 && jumpsLeft < maxJumpsLeft)))
        {
            //double jump
            anim.SetBool("Jump", true);
            StartCoroutine(ResetInput());

        }
        //if we press the q key and are not grounded and have at least one air dash left
        if (Input.GetKeyDown(KeyCode.Q) && !isGrounded() && airdashesLeft > 0)
            //air dash
            airdash();

        rb.velocity =  dir;  
         
    }


    public void Jump()
    {
        //make the jump speed the value for dir.y
            dir.y = jumpSpeed;
        input = "Jump";
    }

    //the speed of double jump will be changed once jumping is refined
    public void DoubleJump()
    {
        //make the jump speed  the value for dir.y;
        dir.y = doubleJumpSpeeed;
    }



    void OnCollisionEnter(Collision col)
    {
        //if we collide with a platform and are below it
        if (col.transform.tag == "Platform" && col.transform.position.y > transform.position.y && dir.y > 0)
        {
            //make the collider a trigger so we can pass through it
            GetComponent<BoxCollider>().isTrigger = true;
            goingThruPlat = true;

        }
        else if (col.transform.tag == "Hitbox" && GetComponentInChildren<PlayerCombat>().parryActive)
        {
            GetComponentInChildren<PlayerCombat>().PlayParryFX();

        }

    }
    void OnTriggerEnter(Collider col)
    {
        //if we collide with a blast zone
        if(col.tag == "BlastZone")
        
            //spawn the death fx at the place where the player crossed the blast zone
            if (col.name == "Right")
                Instantiate(deathFX, transform.position - Vector3.forward * 59f, col.transform.rotation);
            else if (col.name == "Left")
                Instantiate(deathFX, transform.position + Vector3.forward * 59f, col.transform.rotation);
            else if (col.name == "Bottom")
                Instantiate(deathFX, transform.position + Vector3.up * 63f, col.transform.rotation);
            else if (col.name == "Top")
                Instantiate(deathFX, transform.position - Vector3.up * 52f, col.transform.rotation);
        }

    void OnTriggerExit(Collider col)
    {
        //if we exited a platforrm
        if (col.gameObject.tag == "Platform")
        {
            ///make the box collider solid and disable us from passing through platforms after about 5 frames
            GetComponent<BoxCollider>().isTrigger = false;
            StartCoroutine(StopPassingThruPlat());
        }
    }
    

    void airdash()
    {
        //if we have not used all our airdash
        if (airdashesLeft > 0)
        { 
            //move in the direction we are holding at the airdash speed and subtract an airdash
            dir += new Vector3(0, moveV * airdashSpeed, moveH * airdashSpeed);
            airdashesLeft--;
        }
    }
    bool isGrounded()
    {
        //check if either ray touches the ground or a platform and return true or false
        return Physics.Raycast(ltRaycastPoint.position + offset, -Vector3.up, distToGround + 0.1f,platform) ||
                      Physics.Raycast(rtRaycastPoint.position - offset, -Vector3.up, distToGround + 0.1f, platform) ||
                      Physics.Raycast(ltRaycastPoint.position + offset, -Vector3.up, distToGround + 0.1f, floor) ||
                      Physics.Raycast(rtRaycastPoint.position - offset, -Vector3.up, distToGround + 0.1f, floor);
    }

    IEnumerator StopPassingThruPlat()
    {
        //wait for about 3 frames and then stop going through the platforms
        yield return new WaitForSeconds(3 / 60);
        goingThruPlat = false;
    }

    IEnumerator ResetInput()
    {
        yield return new WaitForSeconds(0.15f);
        anim.SetBool(input, false);
    }
}
