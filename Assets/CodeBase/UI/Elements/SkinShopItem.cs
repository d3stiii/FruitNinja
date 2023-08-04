using CodeBase.Services.Shop;
using CodeBase.Services.Shop.Skins;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements
{
    public class SkinShopItem : MonoBehaviour
    {
        [SerializeField] private Button _purchaseButton;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private Image _icon;
        private SkinShopItemDescription _itemDescription;
        private IShopService<SkinShopItemDescription> _shopService;

        public void Construct(SkinShopItemDescription itemDescription, IShopService<SkinShopItemDescription> shopService)
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