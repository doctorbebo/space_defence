using UnityEngine;

namespace Ordnance
{
    public class Propeller : MonoBehaviour
    {
        public float speed;

        private void FixedUpdate()
        {
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        }
    }
}