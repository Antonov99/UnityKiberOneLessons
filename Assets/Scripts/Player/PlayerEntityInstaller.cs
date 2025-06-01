using Collisions;
using Components;
using Gameplay;
using Player;
using UI;
using UnityEngine;
using Zenject;

public class PlayerEntityInstaller : MonoInstaller
{
    private static readonly int _chopAnimHash = Animator.StringToHash("Chop");
    private static readonly int _mineAnimHash = Animator.StringToHash("Mine");

    [SerializeField]
    private GameObject _axe;

    [SerializeField]
    private GameObject _pick;
    
    [SerializeField]
    private float _moveSpeed;
    
    [SerializeField]
    private float _rotationSpeed;

    [SerializeField]
    private Rigidbody _rigidbody;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private CollisionReceiver _collisionReceiver;

    [SerializeField]
    private AnimationEventsDispatcher _animationEventsDispatcher;
    
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

        Container.Bind<DigAnimationComponent>()
            .AsSingle()
            .WithArguments(_axe, _pick, _chopAnimHash, _mineAnimHash)
            .NonLazy();
        
        //Systems:
        Container
            .BindInterfacesAndSelfTo<PlayerMoveController>()
            .AsSingle()
            .NonLazy();
        
        Container
            .BindInterfacesAndSelfTo<PlayerAnimatorDispatcher>()
            .AsSingle()
            .NonLazy();

        Container
            .BindInterfacesAndSelfTo<DigObserver>()
            .AsSingle()
            .WithArguments(_collisionReceiver)
            .NonLazy();
        
        Container.Bind<DigSystem>()
            .AsSingle()
            .WithArguments(_animationEventsDispatcher)
            .NonLazy();
    }
}