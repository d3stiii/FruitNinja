using System;
using System.Collections.Generic;

namespace CodeBase.Data.Persistent
{
    [Serializable]
    public class PurchaseData
    {
        public List<string> BoughtItemIds = new();

        public void AddPurchase(string id)
        {
            if (BoughtItemIds.Contains(id))
                return;

            BoughtItemIds.Add(id);
        }
    }
}