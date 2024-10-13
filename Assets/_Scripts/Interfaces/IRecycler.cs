using UnityEngine;

public interface IRecycler<in T>
{
    void Return(T gameObject);
}