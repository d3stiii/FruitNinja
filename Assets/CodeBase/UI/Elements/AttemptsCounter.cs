using CodeBase.Services.Data;
using TMPro;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Elements
{
    public class AttemptsCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _counter;
        private ISessionDataService _sessionDataService;

        private void Awake() =>
            UpdateCounter();

        [Inject]
        public void Construct(ISessionDataService sessionDataService)
        {
            _sessionDataService = sessionDataService;
            sessionDataService.SessionData.AttemptsData.Changed += UpdateCounter;
        }

        private void OnDestroy() =>
            _sessionDataService.SessionData.AttemptsData.Changed -= UpdateCounter;

        private void UpdateCounter() =>
            _counter.text = _sessionDataService.SessionData.AttemptsData.Value.ToString();
    }
}