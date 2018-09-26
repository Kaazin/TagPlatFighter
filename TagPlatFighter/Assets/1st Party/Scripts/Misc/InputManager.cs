using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public string keyName;
    public string[] gameCommands;
    public KeyCode[] Inputs;

    List<string> bindings;
    void Awake()
    {
        bindings = new List<string>();
        
    }

    
    //what are my possible commands?
    /// <summary>
    /// 1.Attack
    /// 2.Jump
    /// 3.Special
    /// 4.Deflect
    /// 5.Strong
    /// 6.Swap
    /// 7.Assist
    /// 8.Burst
    /// </summary>
    static int[] keycodes;
    
    void Update()
    {
        keycodes = (int[])System.Enum.GetValues(typeof(KeyCode));

        for (int i = 0; i < keycodes.Length; i++)
        {
            //keyName = ((KeyCode)keycodes[i]).ToString();
            //Debug.Log(keyName);


            if (Input.GetKeyDown((KeyCode)keycodes[i]))
            {
                keyName = ((KeyCode)keycodes[i]).ToString();
                Debug.Log(keyName);
            }

        }
    }
}




    
