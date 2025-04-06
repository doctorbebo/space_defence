using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.Linq;

public class MouseController : MonoBehaviour
{
    private static bool ShiftHeld => Keyboard.current.shiftKey.isPressed;
    private static bool ControlHeld => Keyboard.current.ctrlKey.isPressed;
    private static bool LeftClick => Mouse.current.leftButton.wasReleasedThisFrame;
    private static bool RightClick => Mouse.current.rightButton.wasReleasedThisFrame;
    
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (LeftClick || RightClick)
        {
            List<IClickable> clickables = GetClickables().ToList();
            Action<IClickable> action = GetDelegate();
            clickables.ForEach(action);
        }
    }

    private IEnumerable<IClickable> GetClickables()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);
        IEnumerable<IClickable> clickables = null;

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            clickables = hit.collider.GetComponents<IClickable>();
        }

        return clickables ?? Array.Empty<IClickable>();

    }

    private static Action<IClickable> GetDelegate()
    {
        if (LeftClick && ShiftHeld && ControlHeld)
        {
            return c => c.OnLeftShiftControlClick();
        }

        if (LeftClick && ShiftHeld)
        {
            return c => c.OnLeftShiftClick();
        }

        if (LeftClick && ControlHeld)
        {
            return c => c.OnLeftControlClick();
        }

        if (LeftClick)
        {
            return (c => c.OnLeftClick());
        }

        if (RightClick && ShiftHeld && ControlHeld)
        {
            return c => c.OnRightShiftControlClick();
        }

        if (RightClick && ShiftHeld)
        {
            return c => c.OnRightShiftClick();
        }

        if (RightClick && ControlHeld)
        {
            return c => c.OnRightControlClick();
        }

        if (RightClick)
        {
            return (c => c.OnRightClick());
        }

        return c => { Debug.LogWarning("This click combination is not implemented"); };
    }
}

