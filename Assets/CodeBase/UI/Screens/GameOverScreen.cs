using CodeBase.Services.Data;
using CodeBase.States;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.Screens
{
    public class GameOverScreen : BaseScreen
    {
        [SerializeField] private TextMeshProUGUI _sessionScoreText;
        [SerializeField] private TextMeshProUGUI _highScoreText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _menuButton;
        private ISessionDataService _sessionDataService;
        private StateMachine _stateMachine;
        private IPersistentDataService _persistentDataService;

        [Inject]
        public void Construct(ISessionDataService sessionDataService, IPersistentDataService persistentDataService,
            StateMachine stateMachine)
        {
            _persistentDataService = persistentDataService;
            _stateMachine = stateMachine;
            _sessionDataService = sessionDataService;
        }

        protected override void Initialize()
        {
            _sessionScoreText.text = $"Score: {_sessionDataService.SessionData.ScoreData.Score}";
            _highScoreText.text = $"High score: {_persistentDataService.PersistentData.HighScoreData.HighScore}";
            _restartButton.onClick.AddListener(() => _stateMachine.EnterState<RestartState>());
            _menuButton.onClick.AddListener(() => _stateMachine.EnterState<LoadMenuState>());
        }
    }
}