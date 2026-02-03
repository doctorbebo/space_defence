using System.Collections;
using System.Collections.Generic;
using _Core;
using Managers;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour, IClickable
{
    public IntVariable variable;
    
    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.numpadPlusKey.wasPressedThisFrame)
        {
            variable.Value += 100;
        }
        
        if (Keyboard.current.numpadMinusKey.wasPressedThisFrame)
        {
            variable.Value -= 100;
        }
    }
}
