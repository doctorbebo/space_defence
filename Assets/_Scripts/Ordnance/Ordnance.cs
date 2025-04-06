using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Ordnance
{
    public class Ordnance: MonoBehaviour
    {
        [field: SerializeField]
        public OrdnanceSettings OrdnanceSettings { get; private set; }
        
        public Transform TargetTransform { get; set; }

        private TargetingSystem targetingSystem;
        private FireSystem fireSystem;

        private void Awake()
        {
            targetingSystem = new TargetingSystem(this);
            fireSystem = new FireSystem(this);
        }

        private void FixedUpdate()
        {
            targetingSystem.FixedUpdate();
            fireSystem.FixedUpdate();
        }
        private void OnDrawGizmosSelected()
        {
            targetingSystem.OnDrawGizmosSelected();
        }
    }
}