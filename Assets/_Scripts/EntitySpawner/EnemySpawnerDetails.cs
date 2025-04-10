using _Core;
using UnityEngine;

namespace EntitySpawner
{
    [CreateAssetMenu(fileName = "NewEnemySpawnerDetails", menuName = "Space Defense/Enemy Spawner Details")]
    public class EnemySpawnerDetails : EntitySpawnerDetails
    {
        [SerializeField]
        private float spawnHeight = 5f;
    
        [SerializeField]
        private MinMaxFloat x;
    
        [SerializeField]
        private MinMaxFloat z;
    
        public override Vector3 GetSpawnPoint()
        {
            bool b = Random.value > 0.5f;
            float x = b ? this.x.max : this.x.Random;
            float z = b ? this.z.Random :this.z.max;
            return new Vector3(x, spawnHeight, z) * (Random.value > 0.5f ? -1 : 1);
        }
    }
}