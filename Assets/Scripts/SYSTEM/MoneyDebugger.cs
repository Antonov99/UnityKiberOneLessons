using Inventory;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace SYSTEM
{
    public class MoneyDebugger:MonoBehaviour
    {
        [Inject, SerializeField, ShowInInspector]
        private ResourceStorage _resourceStorage;

        
    }
}