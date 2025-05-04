using Components;
using Player;
using UI;
using UnityEngine;
using Zenject;

public class PlayerEntityInstaller : MonoInstaller
{
    [SerializeField]
    private float _moveSpeed;
    
    [SerializeField]
    private float _rotationSpeed;

    [SerializeField]
    private Rigidbody _rigidbody;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private JumpView _jumpView;
    
    public override void InstallBindings()
    {
        //Components:
        Container.Bind<MoveComponent>()
            .AsSingle()
            .WithArguments(_moveSpeed, _rigidbody)
            .NonLazy();
        
        Container.Bind<RotationComponent>()
            .AsSingle()
            .WithArguments(_rotationSpeed, _rigidbody)
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
            .BindInterfacesAndSelfTo<PlayerAnimatorDispatcher>()
            .AsSingle()
            .WithArguments(_jumpView)
            .NonLazy();
    }
}