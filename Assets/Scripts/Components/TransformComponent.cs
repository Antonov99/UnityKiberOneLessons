using JetBrains.Annotations;
using UnityEngine;

namespace Gameplay
{
    [UsedImplicitly]
    public class TransformComponent
    {
        private readonly Transform _transform;

        public TransformComponent(Transform transform)
        {
            _transform = transform;
        }

        public Vector3 GetPosition()
        {
            return _transform.position;
        }

        public void SetPosition(Vector3 position)
        {
            _transform.position = position;
        }
    }
}