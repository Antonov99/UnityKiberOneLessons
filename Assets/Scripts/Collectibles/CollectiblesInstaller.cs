using JetBrains.Annotations;
using Zenject;

namespace Collectibles
{
    [UsedImplicitly]
    public class CollectiblesInstaller : Installer<CollectibleEntityInstaller, CollectiblesInstaller>
    {
        [Inject]
        private CollectibleEntityInstaller _collectibleEntityInstaller;
        
        public override void InstallBindings()
        {
            Container.BindMemoryPool<CollectibleEntityInstaller, MonoMemoryPool<CollectibleEntityInstaller>>()
                .WithInitialSize(10)
                .FromComponentInNewPrefab(_collectibleEntityInstaller)
                .UnderTransformGroup("Coins").NonLazy();
        }
    }
}