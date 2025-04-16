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

        public PlayerMoveController(InputAdapter inputAdapter, MoveComponent moveComponent)
        {
            _inputAdapter = inputAdapter;
            _moveComponent = moveComponent;
        }

        public void Initialize()
        {
            Debug.Log("Init");
            _inputAdapter.OnMove += OnMove;
        }

        private void OnMove(Vector3 direction)
        {
            _moveComponent.Move(direction);
        }

        public void Dispose()
        {
            _inputAdapter.OnMove -= OnMove;
        }
    }
}