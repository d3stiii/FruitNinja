using CodeBase.Services.Data;
using CodeBase.Services.Shop;
using CodeBase.Services.Shop.Skins;
using CodeBase.States;
using CodeBase.UI.Elements;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.Screens
{
    public class SkinShopScreen : BaseScreen
    {
        [SerializeField] private TextMeshProUGUI _coinsText;
        [SerializeField] private Button _backButton;
        [SerializeField] private SkinShopItemsContainer _itemsContainer;
        private IPersistentDataService _persistentDataService;
        private StateMachine _stateMachine;

        protected override void Initialize()
        {
            _backButton.onClick.AddListener(() => _stateMachine.EnterState<MainMenuState>());
            _coinsText.text = _persistentDataService.PersistentData.CreditsData.Value.ToString();
        }

        [Inject]
        public void Construct(StateMachine stateMachine, IPersistentDataService persistentDataService,
            IShopService<SkinShopItemDescription> shopService)
        {
            _stateMachine = stateMachine;
            _persistentDataService = persistentDataService;
            _itemsContainer.Construct(shopService);
        }
    }
}