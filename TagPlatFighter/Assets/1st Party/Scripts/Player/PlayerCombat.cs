using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Animator anim;          //the animator attached the player

    public float resetTime;
    public GameObject ParryFX;
    public bool canAttack, canParry;
    public bool parryActive;
    PlayerMovement playerMovement;
    public string input;
    public AudioSource fair;
    public float smashTimer;
    public float smashTime;
    InputManager ipManager;
    public bool trynaSmash;

    void Awake () 
    {
        //GameObject.Find("InputManager").GetComponent<InputManager>();
        anim = GetComponent<Animator>();
        canAttack = true;
        parryActive = false;
        playerMovement = GetComponentInParent<PlayerMovement>();
	}
	
	void Update () 
    {
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            smashTimer += Time.deltaTime;
        }
        if ((Mathf.Abs(playerMovement.moveH) > 0 ||
            Mathf.Abs(playerMovement.moveV) > 0 && smashTimer >= smashTime))
        {
            trynaSmash = false;
        }
        else
            trynaSmash = false;
        if (Input.GetKeyDown(KeyCode.P) && canAttack && playerMovement.grounded &&
            playerMovement.dir.z == 0 && playerMovement.moveV == 0)
        {
            anim.SetBool("Attack", true);
            StopCoroutine(ResetAttack());
            StartCoroutine(ResetAttack());
        }

        if (Input.GetKeyDown(KeyCode.P) && playerMovement.dir.z != 0
            && playerMovement.moveV == 0 && canAttack && playerMovement.grounded &&
            smashTimer < smashTime)
        {
            trynaSmash = false;

            input = "Ftilt";
            //Debug.Log("Ftilt");
            anim.SetBool(input, true);
            StopCoroutine(ResetInput());
            StartCoroutine(ResetInput());
            smashTimer = 0f;

        }

        if (Input.GetKeyDown(KeyCode.P) && playerMovement.moveV > 0
             && canAttack && playerMovement.grounded &&
            smashTimer < smashTime)
        {
            trynaSmash = false;

            input = "Utilt";
            //Debug.Log("Utilt");
            anim.SetBool(input, true);
            StopCoroutine(ResetInput());
            StartCoroutine(ResetInput());
            smashTimer = 0f;
        }
        if (Input.GetKeyDown(KeyCode.P) && playerMovement.moveV < 0
           && canAttack && playerMovement.grounded &&
            smashTimer < smashTime)
        {
            trynaSmash = false;

            input = "Dtilt";
            //Debug.Log("Dtilt");
            anim.SetBool(input, true);
            StopCoroutine(ResetInput());
            StartCoroutine(ResetInput());
            smashTimer = 0f;
        }


        if (Input.GetKeyDown(KeyCode.P) && playerMovement.dir.z != 0
    && playerMovement.moveV == 0 && canAttack && playerMovement.grounded &&
    smashTimer >= smashTime)
        {
            trynaSmash = true;
            input = "Fsmash";
            //Debug.Log("Fsmash");
            anim.SetBool(input, true);
            StopCoroutine(ResetInput());
            StartCoroutine(ResetInput());
            smashTimer = 0f;

        }

        if (Input.GetKeyDown(KeyCode.P) && playerMovement.moveV > 0
             && canAttack && playerMovement.grounded &&
            smashTimer >= smashTime)
        {
            trynaSmash = true;
            input = "Usmash";
            //Debug.Log("Utilt");
            anim.SetBool(input, true);
            StopCoroutine(ResetInput());
            StartCoroutine(ResetInput());
            smashTimer = 0f;

        }
        if (Input.GetKeyDown(KeyCode.P) && playerMovement.moveV < 0
           && canAttack && playerMovement.grounded &&
            smashTimer >= smashTime)
        {
            trynaSmash = true;
            input = "Dsmash";
            //Debug.Log("Dtilt");
            anim.SetBool(input, true);
            StopCoroutine(ResetInput());
            StartCoroutine(ResetInput());
            smashTimer = 0f;

        }

        if (Input.GetKeyDown(KeyCode.P) && canAttack && !playerMovement.grounded &&
           playerMovement.dir.z == 0 && playerMovement.moveV == 0)
        {
            input = "Attack";
            //Debug.Log("Nair");
            anim.SetBool(input, true);
            StopCoroutine(ResetInput());
            StartCoroutine(ResetInput());
        }

        if (Input.GetKeyDown(KeyCode.P) && playerMovement.GetComponent<Rigidbody>().velocity.z > 0
            && playerMovement.moveV == 0 && canAttack && !playerMovement.grounded)
        {
            input = "Fair";
            //Debug.Log("Fair");
            anim.SetBool("Fair", true);
            StopCoroutine(ResetInput());
            StartCoroutine(ResetInput());
            smashTimer = 0f;


        }
        if (Input.GetKeyDown(KeyCode.P) && playerMovement.GetComponent<Rigidbody>().velocity.z < 0
            && playerMovement.moveV == 0 && canAttack && !playerMovement.grounded)
        {
            input = "Bair";
            //Debug.Log("Bair");
            anim.SetBool("Bair", true);
            StopCoroutine(ResetInput());
            StartCoroutine(ResetInput());
            smashTimer = 0f;
        }

        if (Input.GetKeyDown(KeyCode.P) && playerMovement.moveV > 0
             && canAttack && !playerMovement.grounded)
        {
            input = "Uair";
            Debug.Log("Uair");
            anim.SetBool("Uair", true);
            StopCoroutine(ResetInput());
            StartCoroutine(ResetInput());
            smashTimer = 0f;
        }
        if (Input.GetKeyDown(KeyCode.P) && playerMovement.moveV < 0 && playerMovement.moveH == 0f
             && canAttack && !playerMovement.grounded)
        {
            input = "Dair";
            anim.SetBool("Dair", true);
            StopCoroutine(ResetInput());
            StartCoroutine(ResetInput());
            smashTimer = 0f;

        }
        if (Input.GetKeyDown(KeyCode.P) && playerMovement.moveV < 0
           && canAttack && !playerMovement.grounded)
        {
            input = "Fair";
            anim.SetBool(input, true);
            StopCoroutine(ResetInput());
            StartCoroutine(ResetInput());
            smashTimer = 0f;
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

    }

}
