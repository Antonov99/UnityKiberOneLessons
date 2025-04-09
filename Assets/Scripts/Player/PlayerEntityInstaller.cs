using Components;
using Player;
using UnityEngine;
using Zenject;

public class PlayerEntityInstaller : MonoInstaller
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private Rigidbody _rigidbody;

    [SerializeField]
    private Animator _animator;
    
    public override void InstallBindings()
    {
        //Components:
        Container.Bind<MoveComponent>()
            .AsSingle()
            .WithArguments(_speed, _rigidbody)
            .NonLazy();
        
        Container.Bind<AnimatorComponent>()
            .AsSingle()
            .WithArguments(_animator)
            .NonLazy();
        
        //Systems:
        Container
            .BindInterfacesAndSelfTo<PlayerMoveController>()
            .AsSingle()
            .NonLazy();
        
        Container
            .BindInterfacesAndSelfTo<AnimatorController>()
            .AsSingle()
            .NonLazy();
    }
}