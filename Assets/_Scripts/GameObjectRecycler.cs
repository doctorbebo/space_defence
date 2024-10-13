using System.Collections.Generic;
using UnityEngine;

public class GameObjectRecycler : MonoBehaviour, IRecycler<GameObject>, IObjectPool<GameObject>
{
    private readonly Queue<GameObject> pool = new Queue<GameObject>();
    
    public GameObject objectToClone;
    public Transform parent;

    public void Return(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }

    public GameObject Next()
    {
        return pool.Count > 0 ? pool.Dequeue() : Instantiate(objectToClone, Vector3.zero, Quaternion.identity, parent);
    }
}