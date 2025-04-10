using UnityEngine;

namespace EntitySpawner
{
    [CreateAssetMenu(fileName = "NewEntitySpawnerDetails", menuName = "Space Defense/Spawner Details")]
    public class EntitySpawnerDetails : ScriptableObject
    {
        [SerializeField]
        private GameObject prefab;
        public GameObject Prefab => prefab;
        
        public virtual Vector3 GetSpawnPoint() => Vector3.zero;
    }
}