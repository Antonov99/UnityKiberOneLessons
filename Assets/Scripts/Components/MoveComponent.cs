using UnityEngine;

namespace Components
{
    public class MoveComponent
    {
        private readonly float _speed;
        private readonly Rigidbody _rigidbody;

        public MoveComponent(float speed, Rigidbody rigidbody)
        {
            _speed = speed;
            _rigidbody = rigidbody;
        }

        public void Move(Vector3 direction)
        {
            if (direction == Vector3.zero)
            {
                _rigidbody.velocity = Vector3.zero;
                return;
            }

            float inputMagnitude = direction.magnitude;
            if (inputMagnitude > 1) direction.Normalize();

            _rigidbody.velocity = direction.normalized*_speed;
        }
    }
}