using System;
using CodeBase.Fruits;
using CodeBase.Utilities;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace CodeBase.Services.Fruits
{
    public interface IFruitFactory
    {
        SpawnerRoot GetOrCreateSpawnerRoot();
        Fruit GetOrCreateFruit(FruitType fruitType, Vector3 at, Quaternion rotation);
    }

    public class FruitFactory : IFruitFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IFruitProvider _fruitProvider;
        private readonly ObjectPool<Fruit> _fruitPool;
        private SpawnerRoot _spawnerRoot;
        private FruitType _currentFruitType;

        public FruitFactory(IInstantiator instantiator, IFruitProvider fruitProvider)
        {
            _instantiator = instantiator;
            _fruitProvider = fruitProvider;
            _fruitPool = new ObjectPool<Fruit>(CreateFruit, fruit =>
                {
                    fruit.gameObject.SetActive(true);
                    fruit.Initialize(_fruitPool);
                },
                fruit => fruit.gameObject.SetActive(false));
        }

        public SpawnerRoot GetOrCreateSpawnerRoot()
        {
            if (_spawnerRoot == null)
                _spawnerRoot = Object.Instantiate(_fruitProvider.GetSpawnerRootPrefab());

            return _spawnerRoot;
        }

        public Fruit GetOrCreateFruit(FruitType fruitType, Vector3 at, Quaternion rotation)
        {
            _currentFruitType = fruitType;
            Fruit fruit = _fruitPool.Get(fruit => fruit.Type == fruitType);
            fruit.transform.position = at;
            fruit.transform.rotation = rotation;
            return fruit;
        }

        private Fruit CreateFruit()
        {
            if (_spawnerRoot == null)
            {
                throw new NullReferenceException(
                    $"Spawner root shouldn't be null. Call {nameof(GetOrCreateSpawnerRoot)} method to create Spawner root.");
            }

            var prefab = _fruitProvider.GetFruitPrefab(_currentFruitType);
            return _instantiator.InstantiatePrefabForComponent<Fruit>(prefab, _spawnerRoot.transform);
        }
    }
}