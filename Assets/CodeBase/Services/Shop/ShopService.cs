using System;
using CodeBase.Services.AssetManagement;
using UnityEngine;

namespace CodeBase.Services.Shop
{
    public interface IShopService
    {
        event Action Purchased;
        BladeShopItemDescription[] GetItems();
        void Purchase(string id);
    }

    public class ShopService : IShopService
    {
        private readonly IStaticDataProvider _staticDataProvider;

        public ShopService(IStaticDataProvider staticDataProvider)
        {
            _staticDataProvider = staticDataProvider;
        }

        public event Action Purchased;

        public BladeShopItemDescription[] GetItems()
        {
            //TODO: Remove purchased items from list

            return _staticDataProvider.GetShopItemsData().ShopItems;
        }

        public void Purchase(string id)
        {
            Debug.Log($"Purchased item with id: {id}");
            Purchased?.Invoke();
        }
    }
}