using Collectibles;
using Input;
using Inventory;
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

        Container.Bind<ResourceStorage>().AsSingle().NonLazy();
    }
}