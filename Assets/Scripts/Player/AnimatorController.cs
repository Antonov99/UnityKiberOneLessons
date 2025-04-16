using System;
using Components;
using Input;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

[UsedImplicitly]
public class AnimatorController : IInitializable, IDisposable
{
    private readonly AnimatorComponent _animatorComponent;
    private readonly InputAdapter _inputAdapter;

    public AnimatorController(AnimatorComponent animatorComponent, InputAdapter inputAdapter)
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
        if (obj==Vector3.zero)
            _animatorComponent.SetMove(false);
        else
            _animatorComponent.SetMove(true);
    }

    public void Dispose()
    {
        _inputAdapter.OnMove -= OnMoveAnimation;
    }
}