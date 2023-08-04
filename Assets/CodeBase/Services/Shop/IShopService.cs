using System;
using System.Collections.Generic;

namespace CodeBase.Services.Shop
{
    public interface IShopService<TItem>
    {
        event Action Purchased;
        IEnumerable<TItem> GetAvailableItems();
        void Purchase(TItem item);
    }
}