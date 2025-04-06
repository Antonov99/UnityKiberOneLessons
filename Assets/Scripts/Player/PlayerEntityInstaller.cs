using Components;
using UnityEngine;
using Zenject;

public class PlayerEntityInstaller : MonoInstaller
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private Rigidbody _rigidbody;
    
    public override void InstallBindings()
    {
        Container.Bind<MoveComponent>()
            .AsSingle()
            .WithArguments(_speed, _rigidbody)
            .NonLazy();
        
        
    }
}
