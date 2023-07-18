using CodeBase.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI
{
    public class MainMenuScreen : BaseScreen
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _bladeShopButton;
        private StateMachine _stateMachine;

        protected override void Initialize()
        {
            _playButton.onClick.AddListener(() => _stateMachine.EnterState<LoadGameState>());
        }

        [Inject]
        public void Construct(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
    }
}