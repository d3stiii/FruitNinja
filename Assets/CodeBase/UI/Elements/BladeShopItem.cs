using CodeBase.Services.Shop;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements
{
    public class BladeShopItem : MonoBehaviour
    {
        [SerializeField] private Button _purchaseButton;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private Image _icon;
        private BladeShopItemDescription _itemDescription;
        private IShopService _shopService;

        public void Construct(BladeShopItemDescription itemDescription, IShopService shopService)
        {
            _shopService = shopService;
            _itemDescription = itemDescription;
        }

        public void Initialize()
        {
            _nameText.text = _itemDescription.Name;
            _priceText.text = _itemDescription.Price.ToString();
            _icon.sprite = _itemDescription.Icon;
            _purchaseButton.onClick.AddListener(Purchase);
        }

        private void Purchase() => 
            _shopService.Purchase(_itemDescription);
    }
}