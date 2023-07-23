using CodeBase.Logic;
using CodeBase.Services.Input;
using CodeBase.Services.Pause;
using UnityEngine;
using Zenject;

namespace CodeBase.Blade
{
    [RequireComponent(typeof(Collider))]
    public class Blade : MonoBehaviour, IPauseHandler
    {
        [SerializeField] private float _sliceForce;
        [SerializeField] private float _minSpeed;
        private Vector3 _direction;
        private bool _isSwiping;
        private SphereCollider _collider;
        private Vector3 _previousPosition;
        private IPauseService _pauseService;
        private IInputService _inputService;

        private void Awake()
        {
            _collider = GetComponent<SphereCollider>();
        }

        private void Update()
        {
            if (_pauseService.IsPaused)
                return;
            
            if (_inputService.SliceButtonDown())
            {
                EnableSlicing();
            }
            else if (_inputService.SliceButtonUp())
            {
                DisableSlicing();
            }
            else if (_isSwiping)
            {
                UpdatePosition();
                UpdateDirection();
                ToggleColliderByVelocity();
            }
        }

        private void OnDestroy()
        {
            _pauseService.Unregister(this);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<ISlicable>(out var slicableObj))
            {
                slicableObj.Slice(_direction, transform.position, _sliceForce);
            }
        }

        private void OnDrawGizmos()
        {
            if (_isSwiping)
            {
                Gizmos.DrawSphere(transform.position, _collider.radius);
            }
        }

        [Inject]
        public void Construct(IPauseService pauseService, IInputService inputService)
        {
            _inputService = inputService;
            _pauseService = pauseService;
            _pauseService.Register(this);
        }

        private void EnableSlicing()
        {
            UpdatePosition();

            _collider.enabled = true;
            _isSwiping = true;
        }

        private void DisableSlicing()
        {
            _collider.enabled = false;
            _isSwiping = false;
        }

        private void UpdatePosition()
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0f;
            _previousPosition = transform.position;
            transform.position = position;
        }

        private void UpdateDirection() =>
            _direction = transform.position - _previousPosition;

        private void ToggleColliderByVelocity()
        {
            var velocity = _direction.magnitude / Time.deltaTime;
            _collider.enabled = velocity > _minSpeed;
        }

        public void Pause() { }
        public void Unpause() { }
    }
}