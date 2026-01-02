using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Movement
{
    public class PatternEvoker : MonoBehaviour
    {
        [SerializeField] private Patterns.Names patternName;
        [SerializeField] private bool repeat;

        private IEnumerable<Step> pattern;
        private IEnumerator Start()
        {
            pattern = Patterns.Retrieve(patternName);
            do
            {
                foreach (Step step in pattern)
                {
                    step.Init(gameObject);
                    while (!step.Finished)
                    {
                        step.Update();
                        yield return null;
                    }

                    yield return null;
                }
            } while (repeat);
        }
        
        
    }
}