using System;
using CodeBase.Environment;
using CodeBase.Utilities;
using UnityEngine;

namespace CodeBase.Fruits
{
    [RequireComponent(typeof(Fruit), typeof(FruitSlicer))]
    public class FruitDropper : MonoBehaviour
    {
        private FruitSlicer _fruitSlicer;
        private Fruit _fruit;
        private ObjectPool<Fruit> _fruitPool;

        private void Awake()
        {
            _fruit = GetComponent<Fruit>();
            _fruitSlicer = GetComponent<FruitSlicer>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<DeadZone>(out var deadZone))
            {
                _fruitPool.Release(_fruit);
                if (!_fruitSlicer.Sliced)
                {
                    _fruit.NotifyDrop();
                }
            }
        }

        public void Initialize(ObjectPool<Fruit> pool) =>
            _fruitPool = pool;
    }
}