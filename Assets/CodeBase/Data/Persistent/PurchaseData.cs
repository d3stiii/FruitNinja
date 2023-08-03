using System;
using System.Collections.Generic;
using CodeBase.Services.Shop;

namespace CodeBase.Data.Persistent
{
    [Serializable]
    public class PurchaseData
    {
        public List<BoughtItem> BoughtItems = new();

        public void AddPurchase(BladeShopItemDescription itemDescription)
        {
            BoughtItems.Add(new BoughtItem
            {
                ShopItemId = itemDescription.Id,
                SkinId = itemDescription.SkinId.Id
            });
        }
    }
}