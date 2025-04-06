using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Ordnance
{
    public class FireSystem
    {
        
        private float fireRateTimer = -0.1f;
        private readonly Transform transform;
        private readonly Func<Transform> getTarget;
        private readonly OrdnanceSettings settings;
        

        public FireSystem(Ordnance ordnance)
        {
            transform = ordnance.transform;
            settings = ordnance.OrdnanceSettings;
            getTarget = () => ordnance.TargetTransform;
        }

        public void FixedUpdate()
        {
            if (fireRateTimer < 0)
            {
                Transform target = getTarget();
                if (target)
                {
                    Fire(target);
                    fireRateTimer = settings.FireRate;
                }
            }
            else
            {
                fireRateTimer -= Time.deltaTime;
            }
        }

        private void Fire(Transform target)
        {
            GameObject proj =  Object.Instantiate(settings.ProjectileSettings.Prefab, transform.position, transform.rotation, transform);
            proj.transform.LookAt(target);
            proj.SetActive(true);
            Object.Destroy(proj, settings.ProjectileSettings.LifeSpan);
        }
    }
}