using System;
using UnityEngine;
using UnityEngine.Events;

namespace _Core
{
    public class Timer : MonoBehaviour
    {
        public float time = 5f;
        public bool repeat; 
        public UnityEvent onTimeElapsed; 

        private float timer = 0f;

        private void Start()
        {
            timer = time; 
        }

        private void Update()
        {
            timer -= Time.deltaTime; 
            
            if (timer < 0f)
            {
                onTimeElapsed.Invoke();
                if (repeat)
                {
                    timer = time;
                }
                else
                {
                    enabled = false; 
                }
            }
        }

        public void Restart()
        {
            timer = time;
            enabled = true;
        }
    }
}