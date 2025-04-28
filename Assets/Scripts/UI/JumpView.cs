using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class JumpView : MonoBehaviour
    {
        public event Action OnButtonClick;

        [SerializeField]
        private Button _jumpButton;

        public void OnEnable()
        {
            _jumpButton.onClick.AddListener(OnJumpButtonClick);
        }

        private void OnJumpButtonClick()
        {
            OnButtonClick?.Invoke();
        }

        public void OnDisable()
        {
            _jumpButton.onClick.RemoveListener(OnJumpButtonClick);
        }
    }
}