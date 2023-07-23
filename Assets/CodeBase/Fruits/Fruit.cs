using System;
using CodeBase.Logic;
using CodeBase.Services.Pause;
using CodeBase.Utilities;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace CodeBase.Fruits
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class Fruit : MonoBehaviour, ISlicable, IPauseHandler
    {
        public event Action<Fruit> Sliced;
        public event Action Dropped;

        [SerializeField] private int _cost;
        [SerializeField] private FruitType _type;
        [SerializeField] private GameObject _wholeFruit;
        [SerializeField] private GameObject _slicedFruit;
        [SerializeField] private Slice[] _slices;
        private ObjectPool<Fruit> _fruitPool;
        private Rigidbody _rigidbody;
        private bool _sliced;
        private IPauseService _pauseService;
        private Vector3 _savedVelocity;

        public FruitType Type => _type;
        public int Cost => _cost;

        private void Awake() =>
            _rigidbody = GetComponent<Rigidbody>();

        private void OnEnable()
        {
            _sliced = false;
            _rigidbody.velocity = Vector3.zero;
            SelectWholeModel();
        }

        private void OnDestroy() =>
            _pauseService.Unregister(this);

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<DeadZone>(out var deadZone))
            {
                _fruitPool.Release(this);
                if (!_sliced)
                {
                    Dropped?.Invoke();
                }
            }
        }

        [Inject]
        public void Construct(IPauseService pauseService)
        {
            _pauseService = pauseService;
            _pauseService.Register(this);
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

        public void Pause()
        {
            _savedVelocity = _rigidbody.velocity;
            _rigidbody.isKinematic = true;
        }

        public void Unpause()
        {
            _rigidbody.isKinematic = false;
            _rigidbody.velocity = _savedVelocity;
        }
    }
}