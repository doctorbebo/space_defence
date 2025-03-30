using UnityEngine;

namespace Ordnance
{
    [CreateAssetMenu(fileName = "newProjectile Settings", menuName = "Ordnance/Projectile Setting")]
    public class ProjectileSettings : ScriptableObject
    {
        [field: SerializeField] 
        public string Name { get; private set; } = "Projectile";
        
        [field: SerializeField]
        public GameObject Prefab { get; private set; }
        
        [field: SerializeField] 
        public float Speed { get; private set; } = 25f;

        [field: SerializeField]
        public float LifeSpan { get; private set; } = 10f;
        
        [field: SerializeField]
        public int Damage { get; private set; } = 10;
        
    }
}