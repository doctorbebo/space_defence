using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimedEvent : MonoBehaviour
{
    public float time = 1f;
    public bool repeat = false;
    public UnityEvent onTimerExpires;

    private IEnumerator coroutineReference;
    
    private void OnEnable()
    {
        if (coroutineReference == null)
        {
            coroutineReference = Wait();
        }
        StopCoroutine(coroutineReference);
        StartCoroutine(coroutineReference);
    }

    private void OnDisable()
    {
        StopCoroutine(coroutineReference);
    }

    private IEnumerator Wait()
    {
        do
        {
            yield return new WaitForSeconds(time);
            onTimerExpires.Invoke();
        } 
        while (repeat);
    }
}