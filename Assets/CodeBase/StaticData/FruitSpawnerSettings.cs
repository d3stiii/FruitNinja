using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "ThrowableSpawnerSettings", menuName = "ThrowableObjects/ThrowableSpawnerSettings")]
    public class ThrowableSpawnerSettings : ScriptableObject
    {
        [SerializeField] private float _maxSpawnDelay;
        [SerializeField] private float _minSpawnDelay;
        [SerializeField] private float _maxAngle;
        [SerializeField] private float _minAngle;
        [SerializeField] private float _maxForce;
        [SerializeField] private float _minForce;

        public float MaxSpawnDelay => _maxSpawnDelay;
        public float MinSpawnDelay => _minSpawnDelay;
        public float MaxAngle => _maxAngle;
        public float MinAngle => _minAngle;
        public float MaxForce => _maxForce;
        public float MinForce => _minForce;
    }
}