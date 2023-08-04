using System;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Services.Shop.Skins
{
    [Serializable]
    public class SkinShopItemDescription
    {
        public string Id;
        public int Price;
        public string Name;
        public Sprite Icon;
        public UniqueId SkinId;
    }
}