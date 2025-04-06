using _Core;
using UnityEngine;

namespace EntitySpawner
{
    [CreateAssetMenu(fileName = "NewEntitySpawnerDetails", menuName = "Space Defense/Spawner Details")]
    public class EntitySpawnerDetails : ScriptableObject
    {
        [SerializeField]
        private GameObject prefab;
        public GameObject Prefab => prefab;
    }
}