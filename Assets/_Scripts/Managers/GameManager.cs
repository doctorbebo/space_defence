using UnityEngine;
using UnityEngine.InputSystem;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private void Update()
        {
            if (!Keyboard.current.escapeKey.wasPressedThisFrame) 
                return;
        
            #if UNITY_EDITOR
            // For the editor (only works in the Unity editor)
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            // For a built application
            Application.Quit();
            #endif
        }
    }
}
