using UnityEngine;

namespace CodeBase.Fruits
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class Slice : MonoBehaviour
    {
        private Vector3 _initialPosition;
        private Quaternion _initialRotation;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _initialPosition = transform.localPosition;
            _initialRotation = transform.localRotation;
            _rigidbody = GetComponent<Rigidbody>();
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