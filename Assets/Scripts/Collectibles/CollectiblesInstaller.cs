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
            Container.BindMemoryPool<CollectibleEntityInstaller>().FromInstance(_collectibleEntityInstaller);
        }
    }
}