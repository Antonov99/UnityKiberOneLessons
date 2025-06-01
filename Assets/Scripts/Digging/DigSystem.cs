using Entities;
using JetBrains.Annotations;
using UnityEngine;

namespace Gameplay
{
    [UsedImplicitly]
    public sealed class DigSystem
    {
        public void StartDig(Entity entity)
        {
            Debug.Log("dig");
        }

        public void StopDig()
        {
            Debug.Log("not_dig");
        }
    }
}