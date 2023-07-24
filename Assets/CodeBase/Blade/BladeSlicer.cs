using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Blade
{
    public class BladeSlicer : MonoBehaviour
    {
        [SerializeField] private float _sliceForce;
        private BladeMovement _bladeMovement;

        private void Awake() =>
            _bladeMovement = GetComponent<BladeMovement>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<ISlicable>(out var slicableObj))
            {
                slicableObj.Slice(_bladeMovement.Direction, transform.position, _sliceForce);
            }
        }
    }
}