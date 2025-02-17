using System;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Input
{
    [UsedImplicitly]
    public class InputAdapter:IFixedTickable
    {
        public event Action<Vector3> OnMove;
        
        private readonly Joystick _joystick;

        public InputAdapter(Joystick joystick)
        {
            _joystick = joystick;
        }

        public void FixedTick()
        {
            Vector3 direction = GetDirection();

            OnMove?.Invoke(direction);
        }

        private Vector3 GetDirection()
        {
            float horizontal = _joystick.Horizontal;
            float vertical = _joystick.Vertical;

             var direction = new Vector3(horizontal, 0, vertical);
             float inputMagnitude = direction.magnitude;

             if (inputMagnitude > 1)
                 direction.Normalize();

             return direction;
        }
    }
}