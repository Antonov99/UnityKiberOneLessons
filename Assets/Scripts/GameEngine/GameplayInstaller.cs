using Components;
using Input;
using Player;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField]
    private Joystick _joystick;

    [SerializeField]
    private MoveComponent _moveComponent;

    public override void InstallBindings()
    {
        InputInstaller.Install(Container, _joystick);
        PlayerInstaller.Install(Container, _moveComponent);
    }
}