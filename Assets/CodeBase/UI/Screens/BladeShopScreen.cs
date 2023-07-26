using CodeBase.Services.Data;
using CodeBase.States;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.Screens
{
    public class BladeShopScreen : BaseScreen
    {
        [SerializeField] private TextMeshProUGUI _coinsText;
        [SerializeField] private Button _backButton;
        private IPersistentDataService _persistentDataService;
        private StateMachine _stateMachine;

        protected override void Initialize()
        {
            _backButton.onClick.AddListener(() => _stateMachine.EnterState<MainMenuState>());
            _coinsText.text = _persistentDataService.PersistentData.CreditsData.Value.ToString();
        }

        [Inject]
        public void Construct(StateMachine stateMachine, IPersistentDataService persistentDataService)
        {
            _stateMachine = stateMachine;
            _persistentDataService = persistentDataService;
        }
    }
}