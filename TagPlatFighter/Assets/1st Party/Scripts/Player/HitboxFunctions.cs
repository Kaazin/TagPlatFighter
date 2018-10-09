using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxFunctions : MonoBehaviour
{
    public BoxCollider[] armHitboxes_L;
    public BoxCollider[] armHitboxes_R;
    public BoxCollider[] legHitboxes_L;
    public BoxCollider[] legHitboxes_R;
    public BoxCollider[] bodyHitboxes;
    public BoxCollider[] ShockHitbox;
    public ParticleSystem shockwaveFX;
    //enable hitbox functions
    public void EnableArmHitboxL1()
    {
        armHitboxes_L[0].enabled = true;
    }
    public void EnableArmHitboxL2()
    {
        armHitboxes_L[1].enabled = true;
    }
    public void EnableArmHitboxL3()
    {
        armHitboxes_L[2].enabled = true;
    }
    public void EnableArmHitboxL4()
    {
        armHitboxes_L[3].enabled = true;
    }


    public void EnableArmHitboxR1()
    {
        armHitboxes_R[0].enabled = true;
    }
    public void EnableArmHitboxLR()
    {
        armHitboxes_R[1].enabled = true;
    }
    public void EnableArmHitboxR3()
    {
        armHitboxes_R[2].enabled = true;
    }
    public void EnableArmHitboxR4()
    {
        armHitboxes_R[3].enabled = true;
    }
    //end disable arm hitboxes functions


    //disable Leg hitboxes
    public void EnableLegHitboxL1()
    {
        legHitboxes_L[0].enabled = true;
    }
    public void EnableLegHitboxL2()
    {
        legHitboxes_L[1].enabled = true;
    }
    public void EnableLegHitboxL3()
    {
        legHitboxes_L[2].enabled = true;
    }
    public void EnableLegHitboxL4()
    {
        legHitboxes_L[3].enabled = true;
    }


    public void EnableLegHitboxR1()
    {
        legHitboxes_R[0].enabled = true;
    }
    public void EnableLegHitboxR2()
    {
        legHitboxes_R[1].enabled = true;
    }
    public void EnableLegHitboxR3()
    {
        legHitboxes_R[2].enabled = true;
    }
    public void EnableLegHitboxR4()
    {
        legHitboxes_R[3].enabled = true;
    }

    //enable body hitboxes
    public void EnableBodyHitbox1()
    {
        bodyHitboxes[0].enabled = true;
    }

    //enable shockwave hitboxes
    public void EnableShockwaveHitbox()
    {
        ShockHitbox[0].enabled = true;
        shockwaveFX.Stop();
        shockwaveFX.Play();
    }

    //end enable hitbox functions


    //disable hitbox functions
    //disable arm hitboxes
    public void DisableArmHitboxL1()
    {
        armHitboxes_L[0].enabled = false;
    }
    public void DisableArmHitboxL2()
    {
        armHitboxes_L[1].enabled = false;
    }
    public void DisableArmHitboxL3()
    {
        armHitboxes_L[2].enabled = false;
    }
    public void DisableArmHitboxL4()
    {
        armHitboxes_L[3].enabled = false;
    }


    public void DisableArmHitboxR1()
    {
        armHitboxes_R[0].enabled = false;
    }
    public void DisableArmHitboxLR()
    {
        armHitboxes_R[1].enabled = false;
    }
    public void DisableArmHitboxR3()
    {
        armHitboxes_R[2].enabled = false;
    }
    public void DisableArmHitboxR4()
    {
        armHitboxes_R[3].enabled = false;
    }
    //end disable arm hitboxes functions


        //disable Leg hitboxes
    public void DisableLegHitboxL1()
    {
        legHitboxes_L[0].enabled = false;
    }
    public void DisableLegHitboxL2()
    {
        legHitboxes_L[1].enabled = false;
    }
    public void DisableLegHitboxL3()
    {
        legHitboxes_L[2].enabled = false;
    }
    public void DisableLegHitboxL4()
    {
        legHitboxes_L[3].enabled = false;
    }


    public void DisableLegHitboxR1()
    {
        legHitboxes_R[0].enabled = false;
    }
    public void DisableLegHitboxR2()
    {
        legHitboxes_R[1].enabled = false;
    }
    public void DisableLegHitboxR3()
    {
        legHitboxes_R[2].enabled = false;
    }
    public void DisableLegHitboxR4()
    {
        legHitboxes_R[3].enabled = false;
    }
    //end disable leg hitbox functions

    //disable body hitbox functions
    public void DisableBodyHitbox1()
    {
        bodyHitboxes[0].enabled = false;
    }   

    //disable shockwave hitbox
    public void DisableShockwaveHitbox()
    {
        shockwaveFX.Stop();
        ShockHitbox[0].enabled = false;
    }
    //end disable body hitbox functions
    //end disable hitbox functions

}
