using System;
using System.Collections.Generic;
using Gameplay;
using Sirenix.OdinInspector;

namespace Inventory
{
    [Serializable]
    public class ResourceStorage
    {
        [ShowInInspector]
        private Dictionary<ResourceType, int> _inventory = new();

        public void AddResource(ResourceType type, int value)
        {
            _inventory.Add(type,value);
        }
        
        [Button]
        public void AddValueToResource(ResourceType key, int valueForAdding)
        {
            _inventory[key] += valueForAdding;
        }
        
        [Button]
        public void RemoveValueToResource(ResourceType key, int valueForAdding)
        {
            _inventory[key] -= valueForAdding;
        }
    }
}