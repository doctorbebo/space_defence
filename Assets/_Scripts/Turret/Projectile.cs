using UnityEngine;

namespace Turret
{
    public class Projectile : MonoBehaviour, IHandOff<GameObject>
    {
        private IRecycler<GameObject> recycler;

        public void HandOff(GameObject value)
        {
            if (recycler == null)
            {
                recycler = value.GetComponent<IRecycler<GameObject>>();
                if (recycler == null)
                {
                    Debug.LogWarning("Unable to find Recycler");
                }
            }
        }

        public void Recycle()
        {
            gameObject.SetActive(false);
            recycler.Return(gameObject);
        }
    }
}