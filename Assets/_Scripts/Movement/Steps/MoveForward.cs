using UnityEngine;

namespace Movement.Steps
{
    public class MoveForward : Step
    {
        private readonly float speed;
        private readonly float duration;
        
        private float timeRemaining;

        public MoveForward(float speed, float duration)
        {
            this.speed = speed;
            this.duration = duration;
        }

        public override void Init(GameObject gameObject)
        {
            base.Init(gameObject);
            timeRemaining = duration;
        }

        public override void Update()
        {
            GameObject.transform.Translate(Vector3.forward * (speed * Time.deltaTime));
            timeRemaining -= Time.deltaTime;
            Finished = timeRemaining < 0f;
        }
    }
}