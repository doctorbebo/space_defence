using System;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    public float speed;

    private void FixedUpdate()
    {
        transform.position += Vector3.forward * (speed * Time.deltaTime);
    }
}