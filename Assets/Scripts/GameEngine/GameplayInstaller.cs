using Input;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField]
    private Joystick _joystick;

    public override void InstallBindings()
    {
        InputInstaller.Install(Container, _joystick);
    }
}