using System;
using CodeBase.Fruits;
using CodeBase.Services.AssetManagement;
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
        void Cleanup();
    }

    public class FruitFactory : IFruitFactory
    {
        private const string FruitSpawnerRootPath = "Prefabs/FruitSpawnerRoot";
        private readonly IInstantiator _instantiator;
        private readonly IStaticDataProvider _staticDataProvider;
        private readonly IAssetLoader _assetLoader;
        private readonly ObjectPool<Fruit> _fruitPool;
        private SpawnerRoot _spawnerRoot;
        private FruitType _currentFruitType;

        public FruitFactory(IInstantiator instantiator,
            IStaticDataProvider staticDataProvider, IAssetLoader assetLoader)
        {
            _instantiator = instantiator;
            _staticDataProvider = staticDataProvider;
            _assetLoader = assetLoader;
            _fruitPool = new ObjectPool<Fruit>(CreateFruit, fruit => fruit.gameObject.SetActive(true),
                fruit => fruit.gameObject.SetActive(false));
        }

        public SpawnerRoot GetOrCreateSpawnerRoot()
        {
            if (_spawnerRoot == null)
            {
                _spawnerRoot = Object.Instantiate(_assetLoader.LoadAsset<SpawnerRoot>(FruitSpawnerRootPath));
            }

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

            var fruitData = _staticDataProvider.GetFruitData(_currentFruitType);
            var prefab = fruitData.Prefab;
            var fruit = _instantiator.InstantiatePrefabForComponent<Fruit>(prefab, _spawnerRoot.transform);
            fruit.Initialize(fruitData);
            fruit.GetComponent<FruitDropper>().Initialize(_fruitPool);
            return fruit;
        }

        public void Cleanup()
        {
            _spawnerRoot = null;
            _currentFruitType = default;
            _fruitPool.Clear();
        }
    }
}