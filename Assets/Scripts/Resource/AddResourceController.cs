using System;
using Gameplay;
using Inventory;
using JetBrains.Annotations;
using Zenject;

namespace Resource
{
    [UsedImplicitly]
    public class AddResourceController : IInitializable, IDisposable
    {
        private readonly DigSystem _digSystem;
        private readonly ResourceStorage _resourceStorage;

        public AddResourceController(DigSystem digSystem, ResourceStorage resourceStorage)
        {
            _digSystem = digSystem;
            _resourceStorage = resourceStorage;
        }
        
        public void Initialize()
        {
            _digSystem.OnResourceGathered += OnResourceGathered;
        }

        private void OnResourceGathered(ResourceType type, int value)
        {
            _resourceStorage.AddValueToResource(type,value);
        }

        public void Dispose()
        {
            _digSystem.OnResourceGathered -= OnResourceGathered;
        }
    }
}