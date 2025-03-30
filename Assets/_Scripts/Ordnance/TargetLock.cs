using System.Linq;
using UnityEngine;

namespace Ordnance
{
    public class TargetLock: MonoBehaviour
    {
        [Range(0.01f, 10f)]
        public float rotationSpeed = 0.5f;

        [Tooltip("Angle at which the target is considered locked on.")]
        [Range(0.01f, 10f)]
        public float accuracy = 1f;
        
        private ITargetFinder targetFinder;
        public bool targetLocked = false;
        public Quaternion gunRotation;
        private void Awake()
        {
            targetFinder = GetComponent<ITargetFinder>();
        }

        private void FixedUpdate()
        {
            Transform target = targetFinder.ViableTargets.FirstOrDefault();
            if (!target)
            {
                targetLocked = false;
                return;
            }

            Vector3 lookRotation = target.position - transform.position;

            // Determine the target rotation
            Quaternion targetRotation = Quaternion.LookRotation(lookRotation);
            Quaternion rotation = transform.rotation;

            // Smoothly rotate towards the target
            rotation = Quaternion.Lerp(rotation, targetRotation, rotationSpeed * Time.deltaTime);
            transform.rotation = rotation;
            targetLocked = Quaternion.Angle(rotation, targetRotation) < accuracy;
            gunRotation = rotation;
        }
    }
}