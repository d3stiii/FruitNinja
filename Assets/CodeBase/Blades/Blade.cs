using CodeBase.Services.Input;
using CodeBase.Services.Pause;
using UnityEngine;
using Zenject;

namespace CodeBase.Blades
{
    [RequireComponent(typeof(SphereCollider), typeof(TrailRenderer), typeof(BladeMovement))]
    public class Blade : MonoBehaviour, IPauseHandler
    {
        private SphereCollider _collider;
        private TrailRenderer _lineRenderer;
        private BladeMovement _bladeMovement;
        private Vector3 _previousPosition;
        private IPauseService _pauseService;
        private IInputService _inputService;

        private void Awake()
        {
            _bladeMovement = GetComponent<BladeMovement>();
            _collider = GetComponent<SphereCollider>();
            _lineRenderer = GetComponent<TrailRenderer>();
            DisableSlicing();
        }

        private void Update()
        {
            if (_inputService.SliceButtonUp() || _pauseService.IsPaused)
            {
                DisableSlicing();
            }
            else if (_inputService.SliceButtonDown())
            {
                EnableSlicing();
            }
        }

        private void OnDestroy() =>
            _pauseService.Unregister(this);

        [Inject]
        public void Construct(IPauseService pauseService, IInputService inputService)
        {
            _inputService = inputService;
            _pauseService = pauseService;
            _pauseService.Register(this);
        }

        private void EnableSlicing()
        {
            _lineRenderer.enabled = true;
            _bladeMovement.enabled = true;
            _collider.enabled = true;
        }

        private void DisableSlicing()
        {
            _lineRenderer.enabled = false;
            _collider.enabled = false;
            _bladeMovement.enabled = false;
            _lineRenderer.Clear();
        }

        public void Pause() { }
        public void Unpause() { }
    }
}