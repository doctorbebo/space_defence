using System;
using System.Collections.Generic;
using _Core;
using UnityEngine;

namespace Managers
{
    [CreateAssetMenu(fileName = "newIntVariable", menuName = "Variables/Int", order = 0)]
    public class IntVariable : ScriptableObject
    {
        private readonly List<Action<int>> listeners = new();
        
        [SerializeField] private int startValue;
        [SerializeField] private bool preventNegativeValue;

        private int value;
        public int Value
        {
            get => value;
            set
            {
                if (this.value != value)
                {
                    this.value = preventNegativeValue && value < 0 ? 0 : value;
                    for (int i = listeners.Count - 1; i >= 0; i--)
                    {
                        listeners[i].Invoke(this.value);
                    }
                }
            }
        }

        public void AddListener(Action<int> listener) => listeners.Add(listener);
        public void RemoveListener(Action<int> listener) => listeners.Remove(listener);
        
        public static implicit operator int(IntVariable variable) => variable.value;
        public override string ToString() => value.ToString("N0");
        
        private void OnEnable()
        {
            Debug.Log("IntVariable init", this);
            value = startValue; 
        }
    }
}