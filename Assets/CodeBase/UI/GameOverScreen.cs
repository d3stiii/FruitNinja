using CodeBase.Services.Data;
using CodeBase.States;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI
{
    public class GameOverScreen : BaseScreen
    {
        [SerializeField] private TextMeshProUGUI _sessionScoreText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _menuButton;
        private ISessionDataService _sessionDataService;
        private StateMachine _stateMachine;

        [Inject]
        public void Construct(ISessionDataService sessionDataService, StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _sessionDataService = sessionDataService;
        }

        protected override void Initialize()
        {
            _sessionScoreText.text = $"Score: {_sessionDataService.SessionData.ScoreData.Score}";
            _restartButton.onClick.AddListener(() => _stateMachine.EnterState<RestartState>());
            _menuButton.onClick.AddListener(() => _stateMachine.EnterState<LoadMenuState>());
        }
    }
}