using CodeBase.Fruits.Slices;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Fruits
{
    [RequireComponent(typeof(Fruit), typeof(Rigidbody))]
    public class FruitSlicer : MonoBehaviour, ISlicable
    {
        [SerializeField] private GameObject _wholeFruit;
        [SerializeField] private GameObject _slicedFruit;
        [SerializeField] private Slice[] _slices;
        private Rigidbody _rigidbody;
        private Fruit _fruit;

        public bool Sliced { get; private set; }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _fruit = GetComponent<Fruit>();
        }

        private void OnEnable()
        {
            Sliced = false;
            _rigidbody.velocity = Vector3.zero;
            SelectWholeModel();
        }

        public void Slice(Vector3 direction, Vector3 position, float sliceForce)
        {
            if (Sliced)
                return;

            SelectSlicedModel();
            Rotate(direction);
            AddForceToSlices(direction, position, sliceForce);
            Sliced = true;
            _fruit.NotifySlice();
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