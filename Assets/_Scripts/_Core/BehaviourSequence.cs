using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace _Core
{
    public class BehaviourSequence : MonoBehaviour
    {
        [SerializeField] 
        private bool loop = false;
        
        [Tooltip("-1 will loop infinitely")] 
        [SerializeField] 
        private int loopCount = 1;
        
        [field: SerializeField]
        private List<MonoBehaviour> BehavioursSequence { get; set;  }
        
        private IBehaviourSequence currentBehaviour;
        private int index;
        private bool infiniteLoop = false;

        private void OnValidate()
        {
            foreach (MonoBehaviour behaviour in BehavioursSequence)
            {
                if (behaviour is not IBehaviourSequence)
                {
                    Debug.LogError($"All Behaviours in the sequence must implement {nameof(IBehaviourSequence)}", behaviour);
                }
            }
        }

        private void Awake()
        {
            infiniteLoop = loopCount == -1;
            foreach (MonoBehaviour behaviour in BehavioursSequence)
            {
                behaviour.enabled = false;
            }
            Next();
        }
        
        private void LateUpdate()
        {
            if (currentBehaviour.Finished)
            {
                Next();
            }
        }

        private void Next()
        {
            if (currentBehaviour?.Behaviour)
            {
                currentBehaviour.Behaviour.enabled = false;
            }
            
            if (index < BehavioursSequence.Count)
            {
                currentBehaviour = (IBehaviourSequence)BehavioursSequence[index++];
                currentBehaviour.Behaviour.enabled = true;
            }
            else
            {
                if (loop && (infiniteLoop || loopCount > 1))
                {
                    loopCount--;
                    index = 0;
                    currentBehaviour = (IBehaviourSequence)BehavioursSequence[index++];
                    currentBehaviour.Behaviour.enabled = true;
                }
                else
                {
                    enabled = false;
                }
            }
        }
    }
}