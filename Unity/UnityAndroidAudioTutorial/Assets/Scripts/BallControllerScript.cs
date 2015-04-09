using UnityEngine;

namespace Assets.Scripts
{
    public class BallControllerScript : MonoBehaviour
    {
        public float BallSpeed;
        public float MinXVelocity;
        public float MaxXVelocity;
        public float MinYVelocity;
        public float MaxYVelocity;

        private Rigidbody _rigidbody;

        // Use this for initialization
        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _rigidbody.AddForce(new Vector2(Random.Range(MinXVelocity, MaxXVelocity), Random.Range(MinYVelocity, MaxYVelocity)));
            }
        }

        void FixedUpdate()
        {

        }
    }
}
