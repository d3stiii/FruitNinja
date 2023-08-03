using System.Collections.Generic;
using CodeBase.Services.Shop;
using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "BladeShopItemsData", menuName = "Shop/BladeShopItemsData")]
    public class BladeShopItemsData : ScriptableObject
    {
        [SerializeField] private List<BladeShopItemDescription> _shopItems;

        public List<BladeShopItemDescription> ShopItems => _shopItems;
    }
}