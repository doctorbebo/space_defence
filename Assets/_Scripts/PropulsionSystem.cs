using UnityEngine;

public class PropulsionSystem : MonoBehaviour
{
    public float speed;

    protected void FixedUpdate()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }
}