using System.Collections.Generic;
using CodeBase.Services.Data;
using CodeBase.Services.Skins;
using UnityEngine;

namespace CodeBase.UI.Elements
{
    public class SkinInventoryItemsContainer : MonoBehaviour
    {
        [SerializeField] private SkinInventoryItem _itemPrefab;
        private readonly List<SkinInventoryItem> _items = new();
        private IPersistentDataService _persistentDataService;
        private ISkinsService _skinsService;

        public void Construct(ISkinsService skinsService) =>
            _skinsService = skinsService;

        private void Awake()
        {
            _skinsService.Equipped += RefreshItems;
            RefreshItems();
        }

        private void OnDestroy() =>
            _skinsService.Equipped -= RefreshItems;

        private void RefreshItems()
        {
            ClearItems();
            AddItems();
        }

        private void AddItems()
        {
            foreach (var item in _skinsService.GetOwnedSkins())
            {
                var itemObject = Instantiate(_itemPrefab, transform);
                itemObject.Construct(item, _skinsService);
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