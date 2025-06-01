
using Gameplay;
using JetBrains.Annotations;
using UnityEngine;

namespace Components
{
    [UsedImplicitly]
    public class DigAnimationComponent
    {
        private readonly AnimatorComponent _animatorComponent;
        
        private readonly GameObject _axeObject;
        private readonly GameObject _pickaxeObject;
        
        private readonly int _chopAnimHash;
        private readonly int _mineAnimHash;

        public DigAnimationComponent(
            AnimatorComponent animatorComponent,
            GameObject axeObject, GameObject pickaxeObject,
            int chopAnimHash, int mineAnimHash)
        {
            _animatorComponent = animatorComponent;
            _axeObject = axeObject;
            _pickaxeObject = pickaxeObject;
            _chopAnimHash = chopAnimHash;
            _mineAnimHash = mineAnimHash;
        }

        public void Dig(ResourceType resourceType)
        {
            if (resourceType == ResourceType.WOOD)
            {
                _axeObject.SetActive(true);
                _animatorComponent.SetBool(_chopAnimHash,true);
            }

            if (resourceType == ResourceType.ROCK)
            {
                _pickaxeObject.SetActive(true);
                _animatorComponent.SetBool(_mineAnimHash,true);
            }
        }

        public void StopDig()
        {
            _animatorComponent.SetBool(_chopAnimHash,false);
            _animatorComponent.SetBool(_mineAnimHash,false);
            _axeObject.SetActive(false);
            _pickaxeObject.SetActive(false);
        }
    }
}