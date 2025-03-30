using UnityEngine;

namespace Ordnance
{
    [CreateAssetMenu(fileName = "newOrdnanceSettings", menuName = "Ordnance/Ordnance Setting", order = 0)]
    public class OrdnanceSettings : ScriptableObject
    {
        [field: SerializeField] 
        public string Name { get; private set; } = "Hello";
        
        [field: SerializeField]
        public GameObject Prefab { get; private set; }
        
        [field: SerializeField] 
        public ProjectileSettings ProjectileSettings { get; private set; } = null;
        
        [field: SerializeField, Range(0.1f, 20f)] 
        public float FireRate { get; private set; } = 1f;
        
        [field: SerializeField, Range(0.1f, 20f)] 
        public float Accuracy { get; private set; } = 1f;
        
        [field: SerializeField, Tooltip("How fast the Ordnance rotates towards its target."), Range(0.1f, 20f)]
        public float RotationSpeed { get; private set; } = 1f;
        
        [field: SerializeField, Range(0.1f, 20f)] 
        public float Range { get; private set; } = 8f;
    }
}