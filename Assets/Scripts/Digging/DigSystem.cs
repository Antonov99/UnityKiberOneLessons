using System;
using Components;
using Entities;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    [UsedImplicitly]
    public sealed class DigSystem : IInitializable,IDisposable
    {
        public event Action<Entity> OnResourceEmpty;
        public event Action<ResourceType, int> OnResourceGathered;
        
        private Entity _currentResource;
        private bool _allowDig;

        private readonly AnimationEventsDispatcher _animationEventsDispatcher;
        private readonly RotationComponent _rotationComponent;
        private readonly DigAnimationComponent _animationComponent;

        public DigSystem(
            AnimationEventsDispatcher animationEventsDispatcher,
            RotationComponent rotationComponent,
            DigAnimationComponent animationComponent)
        {
            _animationEventsDispatcher = animationEventsDispatcher;
            _rotationComponent = rotationComponent;
            _animationComponent = animationComponent;
        }

        public void Initialize()
        {
            _animationEventsDispatcher.OnAnimEventInvoked += OnGather;
        }

        public void StartDig(Entity entity)
        {
            _allowDig = true;
            var position = entity.Get<TransformComponent>().GetPosition();
            position.y = 0;
            _rotationComponent.Rotate(position);

            var resourceComponent = entity.Get<ResourceComponent>();
            if (resourceComponent.Current < 1)
                return;
        
            var resourceType = resourceComponent.GetResourceType();

            _animationComponent.StartDig(resourceType);

            _currentResource = entity;
        }

        public void StopDig()
        {
            _animationComponent.StopDig();
            _allowDig = false;
        }

        private void OnGather(string eventName)
        {
            var resourceComponent = _currentResource.Get<ResourceComponent>();
            resourceComponent.Gather();
            
            var resourceType = resourceComponent.GetResourceType();
            OnResourceGathered?.Invoke(resourceType, 1);
            
            Debug.Log(eventName);
            Debug.Log(resourceType);

            if (resourceComponent.Current <= 0)
            {
                StopDig();
                OnResourceEmpty?.Invoke(_currentResource);
            }
            else if (_allowDig) 
                StartDig(_currentResource);
        }

        public void Dispose()
        {
            _animationEventsDispatcher.OnAnimEventInvoked -= OnGather;
        }
    }
}