using CodeBase.Services.Data;
using TMPro;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Elements
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _counter;
        private ISessionDataService _sessionDataService;

        private void Awake() =>
            UpdateCounter();

        [Inject]
        public void Construct(ISessionDataService sessionDataService)
        {
            _sessionDataService = sessionDataService;
            sessionDataService.SessionData.ScoreData.Changed += UpdateCounter;
        }

        private void OnDestroy() =>
            _sessionDataService.SessionData.ScoreData.Changed -= UpdateCounter;

        private void UpdateCounter() =>
            _counter.text = _sessionDataService.SessionData.ScoreData.Value.ToString();
    }
}