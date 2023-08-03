using System.Collections.Generic;
using CodeBase.Services.Shop;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Elements
{
    public class BladeShopItemsContainer : MonoBehaviour
    {
        [SerializeField] private SkinShopItem _itemPrefab;
        private readonly List<SkinShopItem> _items = new();
        private ISkinShopService _shopService;

        [Inject]
        public void Construct(ISkinShopService shopService)
        {
            _shopService = shopService;
        }

        private void Awake()
        {
            _shopService.Purchased += RefreshItems;
            RefreshItems();
        }

        private void OnDestroy() =>
            _shopService.Purchased -= RefreshItems;

        private void RefreshItems()
        {
            ClearItems();
            AddItems();
        }

        private void AddItems()
        {
            foreach (var item in _shopService.GetAvailableItems())
            {
                var itemObject = Instantiate(_itemPrefab, transform);
                itemObject.Construct(item, _shopService);
                itemObject.Initialize();
                _items.Add(itemObject);
            }
        }

        private void ClearItems()
        {
            foreach (var item in _items)
                Destroy(item.gameObject);
            _items.Clear();
        }
    }
}