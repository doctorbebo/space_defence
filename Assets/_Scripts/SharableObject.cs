using System;
using System.Collections.Generic;
using UnityEngine;

public class SharableObject : MonoBehaviour
{
    public static Dictionary<int, Dictionary<Type, object>> shareables = new Dictionary<int, Dictionary<Type, object>>();

    public static T Get<T>(int gameObjectId) where T : new()
    {
        if (!shareables.ContainsKey(gameObjectId))
        {
            shareables[gameObjectId] = new Dictionary<Type, object>();
        }
        
        Dictionary<Type, object> shareable = shareables[gameObjectId];
        Type type = typeof(T);
        
        if (shareable.ContainsKey(type))
        {
            return (T)shareable[type];
        }
        
        T newObj = Activator.CreateInstance<T>();
        shareable.Add(type, newObj);
        return newObj;
    }
}
