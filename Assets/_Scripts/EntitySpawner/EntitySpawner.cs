using System;
using UnityEngine;

namespace EntitySpawner
{
    public class EntitySpawner : MonoBehaviour
    {
        [SerializeField] 
        private EntitySpawnerDetails entitySpawnerDetails;

        [SerializeField] 
        private Transform entityParent;

        public void SpawnEntity()
        {
            Instantiate(entitySpawnerDetails.Prefab, entityParent);
        }
        
        public void SpawnEntity(Transform transform)
        {
            GameObject entity = Instantiate(entitySpawnerDetails.Prefab, transform.position, transform.rotation, transform);
        }
    }
}