using CodeBase.Services.Data;
using TMPro;
using UnityEngine;
using Zenject;

namespace CodeBase.UI
{
    public class AttemptsCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _counter;
        private ISessionDataService _sessionDataService;

        private void Awake() =>
            UpdateAttempts();

        [Inject]
        public void Construct(ISessionDataService sessionDataService)
        {
            _sessionDataService = sessionDataService;
            sessionDataService.SessionData.AttemptsData.Changed += UpdateAttempts;
        }

        private void OnDestroy() =>
            _sessionDataService.SessionData.AttemptsData.Changed -= UpdateAttempts;

        private void UpdateAttempts() =>
            _counter.text = _sessionDataService.SessionData.AttemptsData.AttemptsCount.ToString();
    }
}