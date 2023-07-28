using UnityEngine;

namespace CodeBase.Blade
{
    public class BladeMovement : MonoBehaviour
    {
        [SerializeField] private float _minSpeed;
        private Vector3 _previousPosition;
        private SphereCollider _collider;

        public Vector3 Direction { get; private set; }

        private void Awake() =>
            _collider = GetComponent<SphereCollider>();

        private void OnEnable() =>
            UpdatePosition();

        private void Update()
        {
            UpdatePosition();
            UpdateDirection();
            ToggleColliderByVelocity();
        }

        private void UpdateDirection() =>
            Direction = transform.position - _previousPosition;

        private void UpdatePosition()
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0f;
            _previousPosition = transform.position;
            transform.position = position;
        }

        private void ToggleColliderByVelocity()
        {
            var velocity = Direction.magnitude / Time.deltaTime;
            _collider.enabled = velocity > _minSpeed;
        }
    }
}