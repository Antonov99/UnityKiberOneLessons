using System;
using Collisions;
using Components;
using Entities;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    [UsedImplicitly]
    public sealed class DigObserver : IInitializable,IDisposable
    {
        private readonly CollisionReceiver _collisionReceiver;
        private readonly DigSystem _digSystem;

        public DigObserver(CollisionReceiver collisionReceiver, DigSystem digSystem)
        {
            _collisionReceiver = collisionReceiver;
            _digSystem = digSystem;
        }

        public void Initialize()
        {
            _collisionReceiver.OnEnter += StartDigging;
            _collisionReceiver.OnExit += StopDigging;
        }

        private void StartDigging(Collision collider)
        {
            if (!collider.gameObject.TryGetComponent(out Entity entity))
                return;
            
            if (entity.TryGet<ResourceComponent>() is null)
                return;
            
            _digSystem.StartDig(entity);
        }

        private void StopDigging(Collision collider)
        {
            if (!collider.gameObject.TryGetComponent(out Entity entity))
                return;
            
            if (entity.TryGet<ResourceComponent>() is null)
                return;
            
            _digSystem.StopDig();
        }

        public void Dispose()
        {
            _collisionReceiver.OnEnter -= StartDigging;
            _collisionReceiver.OnExit -= StopDigging;
        }
    }
}