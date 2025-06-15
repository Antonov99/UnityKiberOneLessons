using System;
using Components;
using Input;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

[UsedImplicitly]
public class PlayerAnimatorDispatcher : IInitializable, IDisposable
{
    private static readonly int _isMoving = Animator.StringToHash("Move");
    
    private readonly AnimatorComponent _animatorComponent;
    private readonly InputAdapter _inputAdapter;

    public PlayerAnimatorDispatcher(
        AnimatorComponent animatorComponent,
        InputAdapter inputAdapter)
    {
        _animatorComponent = animatorComponent;
        _inputAdapter = inputAdapter;
    }

    public void Initialize()
    {
        _inputAdapter.OnMove += OnMoveAnimation;
    }

    private void OnMoveAnimation(Vector3 obj)
    {
        _animatorComponent.SetBool(_isMoving, obj != Vector3.zero);
    }

    public void Dispose()
    {
        _inputAdapter.OnMove -= OnMoveAnimation;
    }
}