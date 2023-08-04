using System;
using System.Collections.Generic;
using CodeBase.Services.AssetManagement;
using CodeBase.Services.Data;
using CodeBase.Services.SaveLoad;
using UnityEngine;

namespace CodeBase.Services.Shop.Skins
{
    public class SkinShopService : IShopService<SkinShopItemDescription>
    {
        private readonly IStaticDataProvider _staticDataProvider;
        private readonly IPersistentDataService _persistentDataService;
        private readonly ISaveLoadService _saveLoadService;

        public SkinShopService(IStaticDataProvider staticDataProvider, IPersistentDataService persistentDataService,
            ISaveLoadService saveLoadService)
        {
            _staticDataProvider = staticDataProvider;
            _persistentDataService = persistentDataService;
            _saveLoadService = saveLoadService;
        }

        public event Action Purchased;

        public IEnumerable<SkinShopItemDescription> GetAvailableItems()
        {
            var purchasedItems = _persistentDataService.PersistentData.PurchaseData.BoughtItemIds;

            foreach (var item in _staticDataProvider.GetShopItemsData().ShopItems)
            {
                var boughtItem = purchasedItems.Find(x => x == item.Id);

                if (boughtItem != null)
                    continue;

                yield return item;
            }
        }

        public void Purchase(SkinShopItemDescription item)
        {
            _persistentDataService.PersistentData.PurchaseData.AddPurchase(item.Id);
            _persistentDataService.PersistentData.SkinData.AddSkin(item.SkinId.Id);
            _saveLoadService.Save();
            Purchased?.Invoke();
            Debug.Log($"Purchased item with id: {item.Id}");
        }
    }
}