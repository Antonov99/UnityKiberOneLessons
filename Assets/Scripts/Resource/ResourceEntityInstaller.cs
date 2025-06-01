using Gameplay;
using UnityEngine;
using Zenject;

namespace Resource
{
    public class ResourceEntityInstaller:MonoInstaller
    {
        [SerializeField]
        private Transform _transform;
        
        public override void InstallBindings()
        {
            Container
                .Bind<ResourceComponent>()
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<TransformComponent>()
                .AsSingle()
                .WithArguments(_transform)
                .NonLazy();
        }
    }
}