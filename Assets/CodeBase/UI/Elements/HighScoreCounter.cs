using CodeBase.Services.Data;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Zenject;

namespace CodeBase.UI.Elements
{
    public class HighScoreCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _counter;
        private IPersistentDataService _persistentDataService;
        private ISessionDataService _sessionDataService;

        private void Awake() =>
            UpdateCounter(_persistentDataService.PersistentData.HighScoreData.Value);

        [Inject]
        public void Construct(IPersistentDataService persistentDataService, ISessionDataService sessionDataService)
        {
            _sessionDataService = sessionDataService;
            _persistentDataService = persistentDataService;
            _sessionDataService.SessionData.ScoreData.Changed += CheckAndUpdateHighScore;
        }

        private void CheckAndUpdateHighScore()
        {
            var score = _sessionDataService.SessionData.ScoreData.Value;
            var highScore = _persistentDataService.PersistentData.HighScoreData.Value;

            if (score > highScore)
                UpdateCounter(score);
        }

        private void OnDestroy() =>
            _sessionDataService.SessionData.ScoreData.Changed -= CheckAndUpdateHighScore;

        private void UpdateCounter(int highScore) =>
            _counter.text = $"Best: {highScore}";
    }
}