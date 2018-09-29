using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formulas : MonoBehaviour {

 /*
  *Knockback Formula
  * 
  * ((((((v+bd*s)/10+(((v+bd*s)*bd*(1-(1-s)*0.3))/20))*1.4*(200/(w+100)))+18)*(g/100))+b)*r
v = Victim percent
bd = Base damage
s = Stale move multiplier
w = Target weight
g = KBG
b = BKB
r = Ratio where:
Crouch Cancel = 0.85
Grounded Meteor = 0.8
Charging Smash = 1.2
 */

/*
 * Stale Move Negation Formula
1-(sn/100)
  
S1=8.000
S2=7.594
S3=6.782
S4=6.028
S5=5.274
S6=4.462
S7=3.766
S8=2.954
S9=2.200
}

 */

/*hitstun formula
 * Mathf.Floor(b * 0.4f);
 */

/*(hitlag formula
 * Mathf.Round((((d/2.6+5)* e)*h)*c)-1);
 * d = Damage
h = Hitlag multiplier
e = Electric multiplier (1.5× if electric, 1× otherwise)
c = Crouching multiplier (0.67× if crouching, 1× otherwise)
30 frames is the max amount of hitlag able to be dealt
 */
/*rebound duration
 * 
 * 	Floor((d*15/8+)7.5)
 * 		d = Damage
*/

/*
 * smash charge formula
 * d*(Held Frames/150)
 * d = Damage
 */
}