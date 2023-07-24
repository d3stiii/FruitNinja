using UnityEngine;

namespace CodeBase.Fruits.Slices
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class Slice : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        private Vector3 _initialPosition;
        private Quaternion _initialRotation;

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
        }

        public void AddForce(Vector3 velocity, Vector3 direction, Vector3 position, float sliceForce)
        {
            _rigidbody.velocity = velocity;
            _rigidbody.AddForceAtPosition(direction * sliceForce, position, ForceMode.Impulse);
        }
    }
}