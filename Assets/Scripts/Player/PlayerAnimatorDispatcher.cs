using System;
using Components;
using Input;
using JetBrains.Annotations;
using UI;
using UnityEngine;
using Zenject;

[UsedImplicitly]
public class PlayerAnimatorDispatcher : IInitializable, IDisposable
{
    private static readonly int _isMoving = Animator.StringToHash("Move");
    private static readonly int _jump = Animator.StringToHash("Jump");
    
    private readonly AnimatorComponent _animatorComponent;
    private readonly InputAdapter _inputAdapter;
    private readonly JumpView _jumpView;

    public PlayerAnimatorDispatcher(
        AnimatorComponent animatorComponent,
        InputAdapter inputAdapter, 
        JumpView jumpView)
    {
        _animatorComponent = animatorComponent;
        _inputAdapter = inputAdapter;
        _jumpView = jumpView;
    }

    public void Initialize()
    {
        _inputAdapter.OnMove += OnMoveAnimation;
        _jumpView.OnButtonClick += OnJumpAnimation;
    }

    private void OnMoveAnimation(Vector3 obj)
    {
        _animatorComponent.SetBool(_isMoving, obj != Vector3.zero);
    }

    private void OnJumpAnimation()
    {
        _animatorComponent.SetTrigger(_jump);
    }

    public void Dispose()
    {
        _inputAdapter.OnMove -= OnMoveAnimation;
        _jumpView.OnButtonClick -= OnJumpAnimation;
    }
}