using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private void Update()
    {
        if (!Keyboard.current.escapeKey.wasPressedThisFrame) 
            return;
        
        // For the editor (only works in the Unity editor)
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // For a built application
        Application.Quit();
        #endif
    }
}
