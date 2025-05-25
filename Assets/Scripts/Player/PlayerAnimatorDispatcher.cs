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
    private static readonly int _mine = Animator.StringToHash("Mine");
    
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
        _jumpView.OnButtonClick += OnMineAnimation;
    }

    private void OnMoveAnimation(Vector3 obj)
    {
        _animatorComponent.SetBool(_isMoving, obj != Vector3.zero);
    }

    private void OnMineAnimation()
    {
        _animatorComponent.SetBool(_mine,true);
    }

    public void Dispose()
    {
        _inputAdapter.OnMove -= OnMoveAnimation;
        _jumpView.OnButtonClick -= OnMineAnimation;
    }
}