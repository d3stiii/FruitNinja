using System;
using CodeBase.AssetManagement;
using CodeBase.Bombs;
using CodeBase.Fruits;
using CodeBase.Services.AssetManagement;
using CodeBase.Utilities;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace CodeBase.Services.Bombs
{
    public interface IBombFactory
    {
        SpawnerRoot GetOrCreateSpawnerRoot();
        BombSlicer GetOrCreateBomb(Vector3 at, Quaternion rotation);
        void Cleanup();
    }

    public class BombFactory : IBombFactory, IInitializable
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetLoader _assetLoader;
        private ObjectPool<BombSlicer> _bombsPool;
        private SpawnerRoot _spawnerRoot;
        private BombSlicer _bombSlicerPrefab;

        public BombFactory(IInstantiator instantiator, IAssetLoader assetLoader)
        {
            _instantiator = instantiator;
            _assetLoader = assetLoader;
        }

        public void Initialize()
        {
            _bombsPool = new ObjectPool<BombSlicer>(CreateBomb, bomb => bomb.gameObject.SetActive(true),
                bomb => bomb.gameObject.SetActive(false));
            _bombSlicerPrefab = _assetLoader.LoadAsset<BombSlicer>(AssetsPath.BombPrefabPath);
        }

        public SpawnerRoot GetOrCreateSpawnerRoot()
        {
            if (_spawnerRoot == null)
            {
                _spawnerRoot = Object.Instantiate(_assetLoader.LoadAsset<SpawnerRoot>(AssetsPath.SpawnerRootPath));
                _spawnerRoot.gameObject.name = "BombsSpawnerRoot";
            }

            return _spawnerRoot;
        }

        public BombSlicer GetOrCreateBomb(Vector3 at, Quaternion rotation)
        {
            BombSlicer bombSlicer = _bombsPool.Get();
            bombSlicer.transform.position = at;
            bombSlicer.transform.rotation = rotation;
            return bombSlicer;
        }

        public void Cleanup()
        {
            _spawnerRoot = null;
            _bombsPool.Clear();
        }

        private BombSlicer CreateBomb()
        {
            if (_spawnerRoot == null)
            {
                throw new NullReferenceException(
                    $"Spawner root shouldn't be null. Call {nameof(GetOrCreateSpawnerRoot)} method to create Spawner root.");
            }

            var bomb = _instantiator.InstantiatePrefabForComponent<BombSlicer>(_bombSlicerPrefab,
                _spawnerRoot.transform);
            bomb.GetComponent<BombDropper>().Initialize(_bombsPool);
            return bomb;
        }
    }
}