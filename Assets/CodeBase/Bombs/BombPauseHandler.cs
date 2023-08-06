using CodeBase.Services.Pause;
using UnityEngine;
using Zenject;

namespace CodeBase.Bombs
{
    [RequireComponent(typeof(Rigidbody))]
    public class BombPauseHandler : MonoBehaviour, IPauseHandler
    {
        private Vector3 _savedVelocity;
        private IPauseService _pauseService;
        private Rigidbody _rigidbody;

        private void Awake() =>
            _rigidbody = GetComponent<Rigidbody>();

        private void OnDestroy() =>
            _pauseService.Unregister(this);

        [Inject]
        public void Construct(IPauseService pauseService)
        {
            _pauseService = pauseService;
            _pauseService.Register(this);
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