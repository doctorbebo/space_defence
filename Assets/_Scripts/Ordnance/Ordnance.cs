using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Ordnance
{
    public class Ordnance: MonoBehaviour
    {
        public TargetLock targetLock;
        public float fireRate;
        
        public GameObject projectile;
        public float projectileLifeSpan = 10f;

        private float fireRateTimer;

        private void Start()
        {
            fireRateTimer = fireRate;
        }

        private void Update()
        {
            if (fireRateTimer < 0)
            {
                if (targetLock.targetLocked)
                {
                    Fire();
                    fireRateTimer = fireRate;
                }
            }
            else
            {
                fireRateTimer -= Time.deltaTime;
            }
        }

        private void Fire()
        {
            GameObject proj = Instantiate(projectile, transform.position, targetLock.gunRotation, transform);
            proj.SetActive(true);
            Destroy(proj, projectileLifeSpan);
        }
    }
}