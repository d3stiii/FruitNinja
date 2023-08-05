using CodeBase.Services.Data;
using CodeBase.Services.Skins;
using CodeBase.States;
using CodeBase.UI.Elements;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.Screens
{
    public class SkinInventoryScreen : BaseScreen
    {
        [SerializeField] private TextMeshProUGUI _coinsText;
        [SerializeField] private Button _backButton;
        [SerializeField] private SkinInventoryItemsContainer _itemsContainer;
        private IPersistentDataService _persistentDataService;
        private StateMachine _stateMachine;

        protected override void Initialize()
        {
            _backButton.onClick.AddListener(() => _stateMachine.EnterState<MainMenuState>());
            _coinsText.text = _persistentDataService.PersistentData.CreditsData.Value.ToString();
        }

        [Inject]
        public void Construct(StateMachine stateMachine, IPersistentDataService persistentDataService, ISkinsService screenService)
        {
            _persistentDataService = persistentDataService;
            _stateMachine = stateMachine;
            _itemsContainer.Construct(screenService);
        }
    }
}