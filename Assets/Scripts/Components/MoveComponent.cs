using UnityEngine;

namespace Components
{
    public class MoveComponent : MonoBehaviour
    {
        [SerializeField]
        private float _speed;
        
        [SerializeField]
        private Rigidbody _rigidbody;

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