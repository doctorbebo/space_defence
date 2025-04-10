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
            GameObject clone = Instantiate(entitySpawnerDetails.Prefab, Vector3.zero, Quaternion.identity, entityParent);
            clone.transform.localPosition = entitySpawnerDetails.GetSpawnPoint();
        }
    }
}