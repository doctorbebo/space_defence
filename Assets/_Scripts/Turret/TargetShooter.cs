using System;
using UnityEngine;

namespace Turret
{
    [RequireComponent(typeof(IObjectPool<GameObject>))]
    public class TargetShooter : MonoBehaviour
    {
        private IObjectPool<GameObject> pool;
        private void Awake()
        {
            pool = GetComponent<IObjectPool<GameObject>>();
        }

        public void Fire()
        {
            GameObject projectile = pool.Next();
            projectile.transform.position = transform.position;
            projectile.transform.rotation = transform.rotation;
            projectile.GetComponent<IHandOff<GameObject>>().HandOff(gameObject);
            projectile.SetActive(true);
        }
    }
}