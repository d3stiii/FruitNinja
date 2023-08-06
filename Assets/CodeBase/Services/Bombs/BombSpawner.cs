using System.Collections;
using CodeBase.Bombs;
using CodeBase.Services.AssetManagement;
using CodeBase.StaticData;
using CodeBase.Utilities;
using UnityEngine;
using Zenject;

namespace CodeBase.Services.Bombs
{
    public interface IBombSpawner
    {
        void StartSpawning();
        void StopSpawning();
    }

    public class BombSpawner : IInitializable, IBombSpawner
    {
        private readonly IStaticDataProvider _staticDataProvider;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IBombFactory _bombFactory;
        private ThrowableSpawnerSettings _settings;
        private Coroutine _spawnCoroutine;

        public BombSpawner(IStaticDataProvider staticDataProvider, ICoroutineRunner coroutineRunner,
            IBombFactory bombFactory)
        {
            _staticDataProvider = staticDataProvider;
            _coroutineRunner = coroutineRunner;
            _bombFactory = bombFactory;
        }

        public void Initialize() =>
            _settings = _staticDataProvider.GetBombSpawnerSettings();

        public void StartSpawning() =>
            _spawnCoroutine = _coroutineRunner.StartCoroutine(Spawn());

        public void StopSpawning() =>
            _coroutineRunner.StopCoroutine(_spawnCoroutine);

        private IEnumerator Spawn()
        {
            var spawnerRoot = _bombFactory.GetOrCreateSpawnerRoot();
            var spawnArea = spawnerRoot.GetComponent<Collider>();
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(_settings.MinSpawnDelay, _settings.MaxSpawnDelay));
                var spawnPosition = GetSpawnPosition(spawnArea);
                var rotation = GetRotation();
                BombSlicer bombSlicer = _bombFactory.GetOrCreateBomb(spawnPosition, rotation);
                ThrowUpBomb(bombSlicer);
            }
        }

        private void ThrowUpBomb(BombSlicer bombSlicer)
        {
            var force = bombSlicer.transform.up * Random.Range(_settings.MinForce, _settings.MaxForce);
            bombSlicer.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
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