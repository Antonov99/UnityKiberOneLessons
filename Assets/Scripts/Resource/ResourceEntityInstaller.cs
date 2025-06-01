using Gameplay;
using UnityEngine;
using Zenject;

namespace Resource
{
    public class ResourceEntityInstaller:MonoInstaller
    {
        [SerializeField]
        private Transform _transform;

        [SerializeField]
        private ResourceType _resourceType;

        [SerializeField]
        private int _capacity;
        
        public override void InstallBindings()
        {
            Container
                .Bind<ResourceComponent>()
                .AsSingle()
                .WithArguments(_resourceType, _capacity)
                .NonLazy();
            
            Container
                .Bind<TransformComponent>()
                .AsSingle()
                .WithArguments(_transform)
                .NonLazy();
        }
    }
}