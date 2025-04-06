using System;
using UnityEngine;

namespace Ordnance
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private LayerMask target;


        private void OnTriggerEnter(Collider other)
        {
            if ((target.value & (1 << other.gameObject.layer)) != 0)
            {
                print("Target hit!");
            }
        }
    }
}