using CodeBase.Services.Data;
using TMPro;
using UnityEngine;
using Zenject;

namespace CodeBase.UI
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _counter;
        private ISessionDataService _sessionDataService;

        private void Awake() =>
            UpdateScore();

        [Inject]
        public void Construct(ISessionDataService sessionDataService)
        {
            _sessionDataService = sessionDataService;
            sessionDataService.SessionData.ScoreData.Changed += UpdateScore;
        }

        private void UpdateScore() =>
            _counter.text = _sessionDataService.SessionData.ScoreData.Score.ToString();
    }
}