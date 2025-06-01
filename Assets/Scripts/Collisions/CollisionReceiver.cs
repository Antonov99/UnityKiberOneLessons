using System;
using UnityEngine;

namespace Collisions
{
    public class CollisionReceiver : MonoBehaviour
    {
        public event Action<Collision> OnEnter;
        public event Action<Collision> OnExit;

        private void OnCollisionEnter(Collision other)
        {
            OnEnter?.Invoke(other);
        }

        private void OnCollisionExit(Collision other)
        {
            OnExit?.Invoke(other);
        }
    }
}