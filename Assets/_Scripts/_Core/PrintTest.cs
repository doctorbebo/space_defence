using System;
using Unity.VisualScripting;
using UnityEngine;

namespace _Core
{
    public class PrintTest: MonoBehaviour, IBehaviourSequence
    {
        public string text = string.Empty;
        public int count = 10;

        public MonoBehaviour Behaviour => this;
        public bool Finished { get; set; }

        private int _count;
        private void OnEnable()
        {
            _count = count;
        }

        public void Update()
        {
            print(text + " " + _count);
            _count--;
            Finished = _count <= 0;
        }
    }
}