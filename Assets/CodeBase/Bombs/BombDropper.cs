using CodeBase.Environment;
using CodeBase.Utilities;
using UnityEngine;

namespace CodeBase.Bombs
{
    public class BombDropper : MonoBehaviour
    {
        private BombSlicer _bombSlicer;
        private ObjectPool<BombSlicer> _fruitPool;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _bombSlicer = GetComponent<BombSlicer>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnDisable()
        {
            _rigidbody.velocity = Vector3.zero;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<DeadZone>(out var deadZone))
            {
                _fruitPool.Release(_bombSlicer);
            }
        }

        public void Initialize(ObjectPool<BombSlicer> pool) =>
            _fruitPool = pool;
    }
}