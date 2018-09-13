using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject
{
    public enum charType {Strong_Slow, Quick_Weak, All_Around, Tactical, Combo_Fiend, Zoner, Aggro, Defensive};
    public charType archetype;

    public string name;
    public float groundSpeed;
    public float airSpeed;
    public float jumpSpeed;
    public float doubleJumpSpeed;
    public float fallSpeed;
    public float gravity;
    public float airdashSpeed;
    public float maxJumps;
    public float maxAirdashes;
}
