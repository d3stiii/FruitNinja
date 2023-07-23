using CodeBase.Services.Pause;
using UnityEngine;
using Zenject;

namespace CodeBase.Fruits
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class Slice : MonoBehaviour, IPauseHandler
    {
        [SerializeField] private Rigidbody _rigidbody;
        private Vector3 _initialPosition;
        private Quaternion _initialRotation;
        private Vector3 _savedVelocity;
        private IPauseService _pauseService;

        private void Awake()
        {
            _initialPosition = transform.localPosition;
            _initialRotation = transform.localRotation;
        }

        private void OnEnable()
        {
            transform.localPosition = _initialPosition;
            transform.localRotation = _initialRotation;
            _rigidbody.velocity = Vector3.zero;
            _pauseService.Register(this);
        }

        private void OnDisable() =>
            _pauseService.Unregister(this);

        [Inject]
        public void Construct(IPauseService pauseService) =>
            _pauseService = pauseService;

        public void AddForce(Vector3 velocity, Vector3 direction, Vector3 position, float sliceForce)
        {
            _rigidbody.velocity = velocity;
            _rigidbody.AddForceAtPosition(direction * sliceForce, position, ForceMode.Impulse);
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