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

    void Awake () 
    {
        anim = GetComponent<Animator>();
        canAttack = true;
        parryActive = false;
        playerMovement = GetComponentInParent<PlayerMovement>();
	}
	
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.P) && canAttack && playerMovement.grounded &&
            playerMovement.dir.z == 0 && playerMovement.moveV == 0)
        {
            anim.SetBool("Attack", true);
            StartCoroutine(ResetAttack());
        }

        if (Input.GetKeyDown(KeyCode.P) && playerMovement.dir.z != 0
            && playerMovement.moveV == 0 && canAttack && playerMovement.grounded)
        {
            //Debug.Log("Ftilt");
            //anim.SetBool("Ftilt", true);
        }

        if (Input.GetKeyDown(KeyCode.P) && playerMovement.moveV > 0
             && canAttack && playerMovement.grounded)
        {
            //Debug.Log("Utilt");
            //anim.SetBool("Ftilt", true);
        }
        if (Input.GetKeyDown(KeyCode.P) && playerMovement.moveV < 0
           && canAttack && playerMovement.grounded)
        {
            //Debug.Log("Dtilt");
            //anim.SetBool("Ftilt", true);
        }
        if (Input.GetKeyDown(KeyCode.P) && canAttack && !playerMovement.grounded &&
           playerMovement.dir.z == 0 && playerMovement.moveV == 0)
        {
            input = "Attack";
            //Debug.Log("Nair");
            anim.SetBool(input, true);
            StartCoroutine(ResetInput());
        }

        if (Input.GetKeyDown(KeyCode.P) && playerMovement.GetComponent<Rigidbody>().velocity.z > 0
            && playerMovement.moveV == 0 && canAttack && !playerMovement.grounded)
        {
            input = "Fair";
            //Debug.Log("Fair");
            anim.SetBool("Fair", true);
            StartCoroutine(ResetInput());


        }
        if (Input.GetKeyDown(KeyCode.P) && playerMovement.GetComponent<Rigidbody>().velocity.z < 0
            && playerMovement.moveV == 0 && canAttack && !playerMovement.grounded)
        {
            input = "Bair";
            //Debug.Log("Bair");
            anim.SetBool("Bair", true);
            StartCoroutine(ResetInput());
        }

        if (Input.GetKeyDown(KeyCode.P) && playerMovement.moveV > 0
             && canAttack && !playerMovement.grounded)
        {
            input = "Uair";
            Debug.Log("Uair");
            anim.SetBool("Uair", true);
            StartCoroutine(ResetInput());
        }
        if (Input.GetKeyDown(KeyCode.P) && playerMovement.moveV < 0 && playerMovement.moveH == 0f
             && canAttack && !playerMovement.grounded)
        {
            input = "Dair";
            //anim.SetBool("Dair", true);
            StartCoroutine(ResetInput());

        }
        if (Input.GetKeyDown(KeyCode.P) && playerMovement.moveV < 0
           && canAttack && !playerMovement.grounded)
        {
            //anim.SetBool("Ftilt", true);
            //anim.SetBool("Ftilt", false);
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
        yield return new WaitForSeconds(0.25f);
        anim.SetBool(input, false);

    }
}
