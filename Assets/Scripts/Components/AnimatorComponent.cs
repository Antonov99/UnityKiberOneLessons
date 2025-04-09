using UnityEngine;

namespace Components
{
    public class AnimatorComponent
    {
        private readonly Animator _animator;
        private static readonly int _move = Animator.StringToHash("Move");

        public AnimatorComponent(Animator animator)
        {
            _animator = animator;
        }

        public void SetMove(bool value)
        {
            _animator.SetBool(_move, value);
        }
    }
}