using Collectibles;
using Input;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField]
    private Joystick _joystick;

    [SerializeField]
    private CollectibleEntityInstaller _collectibleEntityInstaller;
    
    public override void InstallBindings()
    {
        InputInstaller.Install(Container, _joystick);
        CollectiblesInstaller.Install(Container, _collectibleEntityInstaller);
    }
}