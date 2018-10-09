using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Animator anim;          //the animator attached the player

    public float resetTime;                //time to reset the animation
    public GameObject ParryFX;            //The parry Particle effecc
    public bool canAttack, canParry;     //bool to check if we can  parry and attack?
    public bool parryActive;            //bool to check if the parry is active
    public PlayerMovement playerMovement;     //the player movement script 
    public string input;
    public float smashTimer;
    public float smashTime;
    public bool trynaSmash;
    //public bool justSmashed = false;
    //public bool inputSmash;
    //float cooldownTimer;
    public float resetTimer;
    public Rigidbody rb;
    public float rushSpeed;
    public bool isRotated;

    GameObject[] hitboxes;




//when a direction is held 
//if the input is less than 0.5f and the timer is greater than the maximum time
//walk
//otherwise if the timer is greater than 0.5 and the timer is greater than the maximum time
//run
    void Awake () 
    {

        //assign variables their default values
        anim = GetComponent<Animator>();
        canAttack = true;
        parryActive = false;
        playerMovement = GetComponentInParent<PlayerMovement>();
        rb = GetComponentInParent<Rigidbody>();
        hitboxes = GameObject.FindGameObjectsWithTag("p1Hitbox");
        foreach(GameObject h in hitboxes)
        {
            h.GetComponent<BoxCollider>().enabled = false;
        }
	}
	
    
	void Update () 
    {
        if (((playerMovement.Haxis != 0 && playerMovement.moveV == 0) ||
            (playerMovement.Haxis == 0 && playerMovement.moveV != 0)))
        {
            smashTimer += Time.deltaTime;
            if (smashTimer <= smashTime)
            {
                trynaSmash = true;
            }
            else
            {
                trynaSmash = false;
            }

        }
        else
        {
            smashTimer = 0;
            trynaSmash = false;
        }

        if (Input.GetKeyDown(KeyCode.P) && canAttack && playerMovement.grounded &&
            playerMovement.dir.z == 0 && playerMovement.moveV == 0)
        {
            input = "Attack";

            anim.SetBool("Attack", true);
            //StopCoroutine(ResetAttack());
            StartCoroutine(ResetAttack());
        }

        if (Input.GetKeyDown(KeyCode.P) && playerMovement.dir.z != 0
            && playerMovement.moveV == 0 && canAttack && playerMovement.grounded && !trynaSmash)
        {
            canAttack = false;
            input = "Ftilt";
            anim.SetBool("Ftilt", true);
            //StopCoroutine(ResetInput());
            StartCoroutine(ResetInput());

        }

        if (Input.GetKeyDown(KeyCode.P) && playerMovement.moveV > 0
             && canAttack && playerMovement.grounded && !trynaSmash)
        {
            canAttack = false;
            input = "Utilt";
            //Debug.Log("Utilt");
            anim.SetBool("Utilt", true);

            //StopCoroutine(ResetInput());
            StartCoroutine(ResetInput());
        }
        if (Input.GetKeyDown(KeyCode.P) && playerMovement.moveV < 0
           && canAttack && playerMovement.grounded && !trynaSmash)
        {
            canAttack = false;
            input = "Dtilt";
            //Debug.Log("Dtilt");
            anim.SetBool("Dtilt", true);

            //StopCoroutine(ResetInput());
            StartCoroutine(ResetInput());
        }


        if (Input.GetKeyDown(KeyCode.P) && playerMovement.dir.z != 0 && playerMovement.moveV == 0 
            && canAttack && playerMovement.grounded && trynaSmash)
        {
            canAttack = false;
            input = "Fsmash";
            //Debug.Log("Fsmash");
            anim.SetBool("Fsmash", true);
            smashTimer = 0;

            //StopCoroutine(ResetInput());
            StartCoroutine(ResetInput());

        }

        if (Input.GetKeyDown(KeyCode.P) && playerMovement.moveV > 0
             && canAttack && playerMovement.grounded && trynaSmash)
        {
            canAttack = false;
            input = "Usmash";
            //Debug.Log("Utilt");
            anim.SetBool("Usmash", true);
            smashTimer = 0;
            //StopCoroutine(ResetInput());
            StartCoroutine(ResetInput());

        }
        if (Input.GetKeyDown(KeyCode.P) && playerMovement.moveV < 0
           && canAttack && playerMovement.grounded && trynaSmash)
        {
            canAttack = false;
            input = "Dsmash";
            //Debug.Log("Dtilt");
            anim.SetBool("Dsmash", true);

            smashTimer = 0;
            //StopCoroutine(ResetInput());
            StartCoroutine(ResetInput());
        }

        if (Input.GetKeyDown(KeyCode.P) && canAttack && !playerMovement.grounded &&
           playerMovement.dir.z == 0 && playerMovement.moveV == 0)
        {
            canAttack = false;
            input = "Attack";
            //Debug.Log("Nair");
            anim.SetBool("Attack", true);

            //StopCoroutine(ResetInput());
            StartCoroutine(ResetInput());
        }

        if (Input.GetKeyDown(KeyCode.P) && playerMovement.GetComponent<Rigidbody>().velocity.z > 0
            && playerMovement.moveV == 0 && canAttack && !playerMovement.grounded)
        {
            canAttack = false;
            input = "Fair";
            //Debug.Log("Fair");
            anim.SetBool("Fair", true);

            //StopCoroutine(ResetInput());
            StartCoroutine(ResetInput());
            //smashTimer = 0f;


        }
        if (Input.GetKeyDown(KeyCode.P) && playerMovement.GetComponent<Rigidbody>().velocity.z < 0
            && playerMovement.moveV == 0 && canAttack && !playerMovement.grounded)
        {
            canAttack = false;
            input = "Bair";
            //Debug.Log("Bair");
            anim.SetBool("Bair", true);

            //StopCoroutine(ResetInput());
            StartCoroutine(ResetInput());
            //smashTimer = 0f;
        }

        if (Input.GetKeyDown(KeyCode.P) && playerMovement.moveV > 0
             && canAttack && !playerMovement.grounded)
        {
            input = "Uair";
            Debug.Log("Uair");
            anim.SetBool("Uair", true);
            resetTimer += Time.deltaTime;
            if (resetTimer >= resetTime)
                anim.SetBool("Uair", false);

            //StopCoroutine(ResetInput());
            StartCoroutine(ResetInput());
            //smashTimer = 0f;
        }
        if (Input.GetKeyDown(KeyCode.P) && playerMovement.moveV < 0 && playerMovement.moveH == 0f
             && canAttack && !playerMovement.grounded)
        {
            input = "Dair";
            anim.SetBool("Dair", true);
            resetTimer += Time.deltaTime;

            //StopCoroutine(ResetInput());
            StartCoroutine(ResetInput());
            //smashTimer = 0f;

        }
        if (Input.GetKeyDown(KeyCode.P) && playerMovement.moveV < 0
           && canAttack && !playerMovement.grounded)
        {
            input = "Fair";
            anim.SetBool("Fair", true);
            resetTimer += Time.deltaTime;
            if (resetTimer >= resetTime)
                anim.SetBool("Fair", false);

            StopCoroutine(ResetInput());
            StartCoroutine(ResetInput());
            //smashTimer = 0f;
        }

        if (Input.GetKeyDown(KeyCode.O) && canAttack &&
           playerMovement.dir.z == 0 && playerMovement.moveV == 0)
        {
            input = "Nspec";
            anim.SetBool("Nspec", true);

            //StopCoroutine(ResetAttack());
            StartCoroutine(ResetInput());
        }

        if (Input.GetKeyDown(KeyCode.O) && playerMovement.dir.z != 0
            && playerMovement.moveV == 0 && canAttack)
        {
            canAttack = false;
            input = "Fspec";
            anim.SetBool("Fspec", true);
            //StopCoroutine(ResetInput());
            StartCoroutine(ResetInput());

        }

        if (Input.GetKeyDown(KeyCode.O) && playerMovement.moveV > 0
             && canAttack)
        {
            canAttack = false;
            input = "Uspec";
            //Debug.Log("Utilt");
            anim.SetBool("Uspec", true);

            //StopCoroutine(ResetInput());
            StartCoroutine(ResetInput());
        }
        if (Input.GetKeyDown(KeyCode.O) && playerMovement.moveV < 0
           && canAttack)
        {
            canAttack = false;
            input = "Dspec";
            //Debug.Log("Dtilt");
            anim.SetBool("Dspec", true);

            //StopCoroutine(ResetInput());
            StartCoroutine(ResetInput());
        }
        if (Input.GetKeyDown(KeyCode.I) && canAttack)
        {
            StartCoroutine(ActivateParry());
        }
    }

    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(resetTime);
        anim.SetBool("Attack", false);
    }

   public void PlayParryFX()
    {
        ParryFX.SetActive(true);
    }

    IEnumerator ResetParry()
    {
        yield return new WaitForSeconds(3);
        ParryFX.SetActive(false);
    }
    IEnumerator ActivateParry()
    {
        canAttack = false;
        GetComponentInParent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(3 / 60);
        parryActive = true;
        //disable the players hitboxes
        Debug.Log("Hitboxes Off");
        yield return new WaitForSeconds(0.15f);
        //parry Over
        Debug.Log("Parry Window completed");
        parryActive = false;
        GetComponentInParent<PlayerMovement>().enabled = true;
        canParry = false;
        StartCoroutine(ResetCanParry());
    }
    IEnumerator ResetCanParry()
    {
        yield return new WaitForSeconds(0.05f);
        canParry = true;
        canAttack = true;
    }
    IEnumerator ResetInput()
    {
        yield return new WaitForSeconds(0.15f);
        anim.SetBool(input, false);
        canAttack = true;

    }
    public void Fspec()
    {
        //make the jump speed the value for dir.y
        playerMovement.dir.z = rushSpeed;
        input = "Fspec";
        playerMovement.enabled = false;
    }

    public void ZeroDir()
    {
        playerMovement.enabled = true;
        playerMovement.dir = Vector3.zero;
        playerMovement.enabled = false;
        rb.velocity = Vector3.zero;
    }

    public void EnableMovement()
    {
        playerMovement.enabled = true;
    }

}
