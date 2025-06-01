using System;
using JetBrains.Annotations;

namespace Gameplay
{
    [UsedImplicitly]
    public sealed class ResourceComponent
    {
        public event Action<ResourceType, int> OnResourceValueChanged;
        public int Capacity { get; }
        public int Current => _current;

        private readonly ResourceType _type;
        private int _current;

        public ResourceComponent(ResourceType type, int capacity)
        {
            _type = type;
            Capacity = capacity;

            _current = capacity;
        }

        public void SetMaxCurrent(int value)
        {
            _current = Capacity;
        }

        public ResourceType GetResourceType()
        {
            return _type;
        }

        public void Gather()
        {
            _current--;
            OnResourceValueChanged?.Invoke(_type, _current);
        }
    }
}