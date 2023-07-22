using System.Collections;
using CodeBase.Extensions;
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
        private readonly IFruitObserver _fruitObserver;
        private FruitSpawnerSettings _settings;

        public FruitSpawner(ICoroutineRunner coroutineRunner, IFruitFactory fruitFactory,
            IStaticDataProvider staticDataProvider, IFruitObserver fruitObserver)
        {
            _coroutineRunner = coroutineRunner;
            _fruitFactory = fruitFactory;
            _staticDataProvider = staticDataProvider;
            _fruitObserver = fruitObserver;
        }

        public void Initialize() =>
            _settings = _staticDataProvider.GetFruitSpawnerSettings();

        public void StartSpawning() =>
            _coroutineRunner.StartCoroutine(Spawn());

        public void StopSpawning() =>
            _coroutineRunner.StopCoroutine(Spawn());

        private IEnumerator Spawn()
        {
            var spawnerRoot = _fruitFactory.GetOrCreateSpawnerRoot();
            var spawnArea = spawnerRoot.GetComponent<Collider>();
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(_settings.MinSpawnDelay, _settings.MaxSpawnDelay));
                var randomFruitType = EnumExtensions<FruitType>.GetRandomValue();
                var spawnPosition = GetSpawnPosition(spawnArea);
                var rotation = GetRotation();
                Fruit fruit = _fruitFactory.GetOrCreateFruit(randomFruitType, spawnPosition, rotation);
                _fruitObserver.SubscribeUpdates(fruit);
                ThrowUpFruit(fruit);
            }
        }

        private void ThrowUpFruit(Fruit fruit)
        {
            var force = fruit.transform.up * Random.Range(_settings.MinForce, _settings.MaxForce);
            fruit.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        }

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