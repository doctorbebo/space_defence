using System;
using UnityEngine;

namespace Ordnance
{
    public class TargetingSystem
    {
        private readonly OrdnanceSettings settings;
        private readonly Action<Transform> setTarget;
        private readonly Transform transform;
        private readonly Collider[] potentialTargets = new Collider[20];
        
        public TargetingSystem(Ordnance ordnance)
        {
            settings = ordnance.OrdnanceSettings;
            transform = ordnance.OrdnanceRotationTransform;
            setTarget = (target) => ordnance.TargetTransform = target;
        }

        public void FixedUpdate()
        {
            Array.Clear(potentialTargets, 0, potentialTargets.Length);
            Physics.OverlapSphereNonAlloc(transform.position, settings.Range, potentialTargets, settings.Target);
            
            Transform target = potentialTargets[0]?.transform;
            if (!target)
            {
                setTarget(null);
                return;
            }
            
            Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);

            // Smoothly rotate towards the target
            Quaternion rotation = Quaternion.Lerp(transform.rotation, targetRotation, settings.RotationSpeed * Time.deltaTime);
            transform.rotation = rotation;
            setTarget(Quaternion.Angle(rotation, targetRotation) < settings.Accuracy ? target : null);
        }

        public void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, settings.Range);
        }
    }
}