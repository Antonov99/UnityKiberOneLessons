﻿using UnityEngine;
using Zenject;

namespace Entities
{
    [RequireComponent(typeof(GameObjectContext))]
    public class Entity : MonoBehaviour
    {
        private DiContainer _container;

        private void Awake()
        {
            _container = GetComponent<GameObjectContext>().Container;
        }
        
        public T Get<T>()
        {
            return _container.Resolve<T>();
        }
    }
}