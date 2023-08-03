using CodeBase.Services.Shop;
using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "BladeShopItemsData", menuName = "Shop/BladeShopItemsData")]
    public class BladeShopItemsData : ScriptableObject
    {
        [SerializeField] private BladeShopItemDescription[] _shopItems;

        public BladeShopItemDescription[] ShopItems => _shopItems;
    }
}