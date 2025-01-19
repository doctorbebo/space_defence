using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Targeting
{
    internal class TargetFinder : MonoBehaviour, ITargetFinder
    {
        public IEnumerable<Transform> ViableTargets => potentialTargets.Where(c => c).Select(c => c.transform);
        
        [SerializeField] private float radius = 5;
        [SerializeField] private LayerMask include;

        private Collider[] potentialTargets = new Collider[20];

        private void FixedUpdate()
        {
            Array.Clear(potentialTargets, 0, potentialTargets.Length);
            Physics.OverlapSphereNonAlloc(transform.position, radius, potentialTargets, include);
        }

        private void OnDrawGizmosSelected()
        {
            // Draw a yellow sphere at the transform's position
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}