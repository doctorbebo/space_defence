using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickEventManager : MonoBehaviour, IClickable
{
    public UnityEvent onLeftClick;
    public UnityEvent onRightClick;

    private void Start()
    {
        onLeftClick.AddListener(() => { Debug.Log( $"{transform.parent.name} left click"); });
        onRightClick.AddListener(() => { Debug.Log($"{transform.parent.name} right click"); });
    }

    public void OnLeftClick()
    {
        onLeftClick.Invoke();
    }
    
    public void OnRightClick()
    {
        onRightClick.Invoke();
    }
}
