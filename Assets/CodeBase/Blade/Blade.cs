using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Blade
{
    [RequireComponent(typeof(Collider))]
    public class Blade : MonoBehaviour
    {
        [SerializeField] private float _sliceForce;
        [SerializeField] private float _minSpeed;
        private Vector3 _direction;
        private bool _isSwiping;
        private SphereCollider _collider;
        private Vector3 _previousPosition;

        private void Awake()
        {
            _collider = GetComponent<SphereCollider>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                EnableSlicing();
            }
            else if (Input.GetMouseButtonUp(0))
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
    }
}