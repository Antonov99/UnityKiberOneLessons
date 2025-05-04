using UnityEngine;

namespace Components
{
    public class RotationComponent 
    {
        private readonly float _speed;
        private readonly Rigidbody _rigidbody;

        public RotationComponent(float speed, Rigidbody rigidbody)
        {
            _speed = speed;
            _rigidbody = rigidbody;
        }

        public void Rotate(Vector3 direction)
        {
            if (direction == Vector3.zero)
            {
                return;
            }

            float inputMagnitude = direction.magnitude;
            if (inputMagnitude > 1) direction.Normalize();
            
            _rigidbody.rotation = Quaternion.LookRotation(direction.normalized*_speed);
        }
    }
}