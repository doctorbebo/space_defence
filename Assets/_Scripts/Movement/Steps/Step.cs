using UnityEngine;

namespace Movement
{
    public abstract class Step
    {
        protected GameObject GameObject;
        
        public bool Finished { get; protected set; }
        
        public virtual void Init(GameObject gameObject)
        {
            GameObject = gameObject;
            Finished = false;
        }

        public abstract void Update();
    }
}