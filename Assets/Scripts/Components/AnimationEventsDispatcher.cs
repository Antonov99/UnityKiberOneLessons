using System;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Animator))]
    public class AnimationEventsDispatcher : MonoBehaviour
    {
        public event Action<string> OnAnimEventInvoked; 

        internal void ReceiveEvent(string animEvent)
        {
            OnAnimEventInvoked?.Invoke(animEvent);
        }
    }
}