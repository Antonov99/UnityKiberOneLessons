using Components;
using Zenject;

namespace Collectibles
{
    public class CollectibleEntityInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ResourceComponent>().AsSingle().NonLazy();
        }
    }
}