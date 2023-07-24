using CodeBase.Services.Pause;
using UnityEngine;
using Zenject;

namespace CodeBase.Fruits.Slices
{
    [RequireComponent(typeof(Rigidbody))]
    public class SlicePauseHandler : MonoBehaviour, IPauseHandler
    {
        private Rigidbody _rigidbody;
        private Vector3 _savedVelocity;
        private IPauseService _pauseService;

        private void Awake() =>
            _rigidbody = GetComponent<Rigidbody>();

        private void OnEnable() =>
            _pauseService.Register(this);

        private void OnDisable() =>
            _pauseService.Unregister(this);

        [Inject]
        public void Construct(IPauseService pauseService) =>
            _pauseService = pauseService;

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