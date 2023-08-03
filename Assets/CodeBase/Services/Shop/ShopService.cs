using System;
using System.Collections.Generic;
using CodeBase.Services.AssetManagement;
using CodeBase.Services.Data;
using CodeBase.Services.SaveLoad;
using UnityEngine;

namespace CodeBase.Services.Shop
{
    public interface IShopService
    {
        event Action Purchased;
        IEnumerable<BladeShopItemDescription> GetAvailableItems();
        void Purchase(BladeShopItemDescription item);
    }

    public class ShopService : IShopService
    {
        private readonly IStaticDataProvider _staticDataProvider;
        private readonly IPersistentDataService _persistentDataService;
        private readonly ISaveLoadService _saveLoadService;

        public ShopService(IStaticDataProvider staticDataProvider, IPersistentDataService persistentDataService,
            ISaveLoadService saveLoadService)
        {
            _staticDataProvider = staticDataProvider;
            _persistentDataService = persistentDataService;
            _saveLoadService = saveLoadService;
        }

        public event Action Purchased;

        public IEnumerable<BladeShopItemDescription> GetAvailableItems()
        {
            var purchasedItems = _persistentDataService.PersistentData.PurchaseData.BoughtItems;

            foreach (var item in _staticDataProvider.GetShopItemsData().ShopItems)
            {
                var boughtItem = purchasedItems.Find(x => x.ShopItemId == item.Id);

                if (boughtItem != null)
                    continue;

                yield return item;
            }
        }

        public void Purchase(BladeShopItemDescription item)
        {
            Debug.Log($"Purchased item with id: {item.Id}");
            _persistentDataService.PersistentData.PurchaseData.AddPurchase(item);
            _saveLoadService.Save();
            Purchased?.Invoke();
        }
    }
}