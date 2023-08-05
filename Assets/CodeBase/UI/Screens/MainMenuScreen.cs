using CodeBase.Services.Data;
using CodeBase.States;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.Screens
{
    public class MainMenuScreen : BaseScreen
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _skinShopButton;
        [SerializeField] private Button _skinInventoryButton;
        [SerializeField] private TextMeshProUGUI _coinsText;
        private StateMachine _stateMachine;
        private IPersistentDataService _persistentDataService;

        protected override void Initialize()
        {
            _playButton.onClick.AddListener(() => _stateMachine.EnterState<LoadGameState>());
            _exitButton.onClick.AddListener(() => _stateMachine.EnterState<ExitGameState>());
            _skinShopButton.onClick.AddListener(() => _stateMachine.EnterState<SkinShopState>());
            _skinInventoryButton.onClick.AddListener(() => _stateMachine.EnterState<SkinInventoryState>());
            _persistentDataService.PersistentData.CreditsData.Changed += RefreshCoinsText;
            RefreshCoinsText();
        }

        [Inject]
        public void Construct(StateMachine stateMachine, IPersistentDataService persistentDataService)
        {
            _persistentDataService = persistentDataService;
            _stateMachine = stateMachine;
        }

        private void RefreshCoinsText() =>
            _coinsText.text = _persistentDataService.PersistentData.CreditsData.Value.ToString();
    }
}