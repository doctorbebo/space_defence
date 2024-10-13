using UnityEngine;

namespace Turret
{
    public class Forward : MonoBehaviour
    {
        public float speed = 1f;

        // Update is called once per frame
        private void Update()
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
    }
}
