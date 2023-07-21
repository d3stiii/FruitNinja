﻿using System;
using System.Collections;
using CodeBase.Fruits;
using CodeBase.Services.AssetManagement;
using CodeBase.StaticData;
using CodeBase.Utilities;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace CodeBase.Services.Fruits
{
    public interface IFruitSpawner
    {
        void StartSpawning();
        void StopSpawning();
    }

    public class FruitSpawner : IFruitSpawner, IInitializable
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IFruitFactory _fruitFactory;
        private readonly IStaticDataProvider _staticDataProvider;
        private readonly Array _fruitTypeIds = Enum.GetValues(typeof(FruitType));
        private FruitSpawnerSettings _settings;

        public FruitSpawner(ICoroutineRunner coroutineRunner, IFruitFactory fruitFactory,
            IStaticDataProvider staticDataProvider)
        {
            _coroutineRunner = coroutineRunner;
            _fruitFactory = fruitFactory;
            _staticDataProvider = staticDataProvider;
        }

        public void Initialize() =>
            _settings = _staticDataProvider.GetFruitSpawnerSettings();

        public void StartSpawning()
        {
            var spawnerRoot = _fruitFactory.GetOrCreateSpawnerRoot();
            _coroutineRunner.StartCoroutine(Spawn(spawnerRoot.GetComponent<Collider>()));
        }

        public void StopSpawning()
        {
            var spawnerRoot = _fruitFactory.GetOrCreateSpawnerRoot();
            _coroutineRunner.StopCoroutine(Spawn(spawnerRoot.GetComponent<Collider>()));
        }

        private IEnumerator Spawn(Collider spawnArea)
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(_settings.MinSpawnDelay, _settings.MaxSpawnDelay));
                var randomFruitType = GetRandomFruitType();
                var spawnPosition = GetSpawnPosition(spawnArea);
                var rotation = GetRotation();
                Fruit fruit = _fruitFactory.GetOrCreateFruit(randomFruitType, spawnPosition, rotation);
                ThrowUpFruit(fruit);
            }
        }

        private void ThrowUpFruit(Fruit fruit)
        {
            var force = fruit.transform.up * Random.Range(_settings.MinForce, _settings.MaxForce);
            fruit.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        }

        private FruitType GetRandomFruitType() =>
            (FruitType)_fruitTypeIds.GetValue(Random.Range(1, _fruitTypeIds.Length));

        private Quaternion GetRotation() =>
            Quaternion.Euler(0, 0, Random.Range(_settings.MinAngle, _settings.MaxAngle));

        private Vector3 GetSpawnPosition(Collider spawnArea)
        {
            var bounds = spawnArea.bounds;
            var spawnPosition = new Vector3(Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y),
                Random.Range(bounds.min.z, bounds.max.z));

            return spawnPosition;
        }
    }
}