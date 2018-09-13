using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Character))]
public class CharacterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Character myCharacter = (Character)target;

        EditorGUILayout.LabelField("Ground Speed: ", myCharacter.groundSpeed.ToString());
        myCharacter.groundSpeed = EditorGUILayout.Slider(myCharacter.groundSpeed, 0, 1000);

        EditorGUILayout.LabelField("Air Speed: ", myCharacter.airSpeed.ToString());
        myCharacter.airSpeed = EditorGUILayout.Slider(myCharacter.airSpeed, 0, 700);

        EditorGUILayout.LabelField("Jump Speed: ", myCharacter.jumpSpeed.ToString());
        myCharacter.jumpSpeed = EditorGUILayout.Slider(myCharacter.jumpSpeed, 0, 25);

        EditorGUILayout.LabelField("Double Jump Speed: ", myCharacter.doubleJumpSpeed.ToString());
        myCharacter.doubleJumpSpeed = EditorGUILayout.Slider(myCharacter.doubleJumpSpeed, 0, 1000);

        EditorGUILayout.LabelField("Gravity: ", myCharacter.gravity.ToString());
        myCharacter.gravity = EditorGUILayout.Slider(myCharacter.gravity, 1, 50);

        EditorGUILayout.LabelField("Fall Speed: ", myCharacter.fallSpeed.ToString());
        myCharacter.fallSpeed = EditorGUILayout.Slider(myCharacter.fallSpeed, 0, 2);
    }
}
