using UnityEngine;

namespace Movement.Steps
{
    public class Turn: Step
    {
        private const float Tolerance = 0.001f;
        
        private readonly float speed;
        private readonly float turnSpeed;
        private readonly Vector3 targetDir;

        private Transform transform;
        

        public Turn(float speed, float turnSpeed, Vector3 dir)
        {
            this.speed = speed;
            this.turnSpeed = turnSpeed;
            targetDir = dir;
        }

        public override void Init(GameObject gameObject)
        {
            base.Init(gameObject);
            transform = GameObject.transform;
        }

        public override void Update()
        {
            Vector3 position = transform.position;
            Vector3 dir = new(
                targetDir.x - position.x,
                0f,
                targetDir.z - position.z
            );

            if (dir.sqrMagnitude == 0f) return;

            Quaternion targetRot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRot,
                turnSpeed * Time.deltaTime
            );
            
            GameObject.transform.Translate(Vector3.forward * (speed * Time.deltaTime));
            Finished = Vector3.Angle(transform.forward, dir) < Tolerance;
        }
    }
}