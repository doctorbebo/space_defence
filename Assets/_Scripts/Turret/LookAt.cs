using System;
using UnityEngine;

namespace Turret
{
    public class LookAt : MonoBehaviour
    {
        [Range(1, 100)]
        [Tooltip("1 very slow, 100 instantaneous")]
        public int speed = 100;
        
        public float threshold = 0.1f;


        private Observable<Transform> targetObserver;
        private Observable<bool> lockedOnTarget;
        
        private Transform target;

        private bool locked;
        private bool Locked
        {
            get => locked;
            set
            {
                if (locked != value)
                {
                    Debug.Log("Locked: " + value);
                    locked = value;
                    lockedOnTarget.Value = value;
                }
            }
        }
        
        private void Awake()
        {
            targetObserver = SharableObject.Get<Observable<Transform>>(gameObject.GetHashCode());
            lockedOnTarget = SharableObject.Get<Observable<bool>>(gameObject.GetHashCode());
        }
        private void OnEnable() => targetObserver.AddObserver(AssignTarget);
        private void OnDisable() => targetObserver.RemoveObserver(AssignTarget);

        private void FixedUpdate()
        {
            if (!target)
            {
                Locked = false;
                return;
            }

            if (Locked)
            {
                transform.LookAt(target.position);
                return;
            }
            
            Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.localRotation, desiredRotation, speed / 100.0f);
            Locked = Quaternion.Angle(transform.rotation, desiredRotation) < threshold;
        }

        private void OnDrawGizmos()
        {
            Debug.DrawLine(transform.position, transform.forward * 100, Color.red);
        }

        private void AssignTarget(Transform tran) => target = tran;
    }
}