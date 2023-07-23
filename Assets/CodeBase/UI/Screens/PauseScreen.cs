using CodeBase.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.Screens
{
    public class PauseScreen : BaseScreen
    {
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _restartButton;
        private StateMachine _stateMachine;

        [Inject]
        public void Construct(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        protected override void Initialize()
        {
            _resumeButton.onClick.AddListener(() => _stateMachine.EnterState<GameplayState>());
            _menuButton.onClick.AddListener(() => _stateMachine.EnterState<ConstructMenuState>());
            _restartButton.onClick.AddListener(() => _stateMachine.EnterState<RestartState>());
        }
    }
}