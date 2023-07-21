using CodeBase.Utilities;
using UnityEngine;

namespace CodeBase.Fruits
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class Fruit : MonoBehaviour
    {
        [SerializeField] private FruitType _type;
        private ObjectPool<Fruit> _fruitPool;
        private Rigidbody _rigidbody;

        public FruitType Type => _type;

        private void Awake() =>
            _rigidbody = GetComponent<Rigidbody>();

        public void Initialize(ObjectPool<Fruit> pool)
        {
            _rigidbody.velocity = Vector3.zero;
            _fruitPool = pool;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<DeadZone>(out var deadZone))
                _fruitPool.Release(this);
        }
    }
}