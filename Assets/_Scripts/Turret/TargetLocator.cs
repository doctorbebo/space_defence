using System;
using UnityEngine;

namespace Turret
{
    public class TargetLocator : MonoBehaviour
    {
        private Observable<Transform> targetObserver;
        public LayerMask targetableLayers = -1;

        private void Awake()
        {
            targetObserver = SharableObject.Get<Observable<Transform>>(gameObject.GetHashCode());
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (targetableLayers.ContainsLayer(other.gameObject.layer))
            {
                targetObserver.Value = other.transform;
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.transform == targetObserver.Value)
            {
                targetObserver.Value = null;
            }
        }
    }
}