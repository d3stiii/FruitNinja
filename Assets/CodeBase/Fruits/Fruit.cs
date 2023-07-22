using System;
using CodeBase.Logic;
using CodeBase.Utilities;
using UnityEngine;

namespace CodeBase.Fruits
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class Fruit : MonoBehaviour, ISlicable
    {
        public event Action<Fruit> Sliced;

        [SerializeField] private int _scoreCost;
        [SerializeField] private FruitType _type;
        [SerializeField] private GameObject _wholeFruit;
        [SerializeField] private GameObject _slicedFruit;
        [SerializeField] private Slice[] _slices;
        private ObjectPool<Fruit> _fruitPool;
        private Rigidbody _rigidbody;
        private bool _sliced;

        public FruitType Type => _type;
        public int ScoreCost => _scoreCost;

        private void Awake() =>
            _rigidbody = GetComponent<Rigidbody>();

        private void OnEnable()
        {
            _sliced = false;
            _rigidbody.velocity = Vector3.zero;
            SelectWholeModel();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<DeadZone>(out var deadZone))
            {
                _fruitPool.Release(this);
            }
        }

        public void Initialize(ObjectPool<Fruit> pool) =>
            _fruitPool = pool;

        public void Slice(Vector3 direction, Vector3 position, float sliceForce)
        {
            if (_sliced)
                return;

            SelectSlicedModel();
            Rotate(direction);
            AddForceToSlices(direction, position, sliceForce);
            _sliced = true;
            Sliced?.Invoke(this);
        }

        private void Rotate(Vector3 direction)
        {
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _slicedFruit.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }

        private void SelectSlicedModel()
        {
            _wholeFruit.SetActive(false);
            _slicedFruit.SetActive(true);
        }

        private void SelectWholeModel()
        {
            _wholeFruit.SetActive(true);
            _slicedFruit.SetActive(false);
        }

        private void AddForceToSlices(Vector3 direction, Vector3 position, float sliceForce)
        {
            foreach (var slice in _slices)
            {
                slice.AddForce(_rigidbody.velocity, direction, position, sliceForce);
            }
        }
    }
}