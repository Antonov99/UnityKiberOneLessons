using System;
using Components;
using Input;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Player
{
    [UsedImplicitly]
    public class PlayerMoveController : IInitializable, IDisposable
    {
        private readonly InputAdapter _inputAdapter;
        private readonly MoveComponent _moveComponent;
        private readonly RotationComponent _rotationComponent;

        public PlayerMoveController(
            InputAdapter inputAdapter,
            MoveComponent moveComponent,
            RotationComponent rotationComponent)
        {
            _inputAdapter = inputAdapter;
            _moveComponent = moveComponent;
            _rotationComponent = rotationComponent;
        }

        public void Initialize()
        {
            _inputAdapter.OnMove += OnMove;
        }

        private void OnMove(Vector3 direction)
        {
            _moveComponent.Move(direction);
            _rotationComponent.Rotate(direction);
        }

        public void Dispose()
        {
            _inputAdapter.OnMove -= OnMove;
        }
    }
}