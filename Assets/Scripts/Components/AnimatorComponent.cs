using UnityEngine;

namespace Components
{
    public class AnimatorComponent
    {
        private readonly Animator _animator;
        
        public AnimatorComponent(Animator animator)
        {
            _animator = animator;
        }

        public void SetBool(int name, bool value)
        {
            _animator.SetBool(name, value);
        }

        public void SetTrigger(int name)
        {
            _animator.SetTrigger(name);
        }
    }
}