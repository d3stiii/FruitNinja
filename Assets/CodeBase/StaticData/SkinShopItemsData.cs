using System.Collections.Generic;
using CodeBase.Services.Shop;
using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "SkinShopItemsData", menuName = "Shop/SkinShopItemsData")]
    public class SkinShopItemsData : ScriptableObject
    {
        [SerializeField] private List<SkinShopItemDescription> _shopItems;

        public List<SkinShopItemDescription> ShopItems => _shopItems;
    }
}