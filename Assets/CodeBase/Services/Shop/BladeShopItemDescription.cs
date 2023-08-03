using System;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Services.Shop
{
    [Serializable]
    public class BladeShopItemDescription
    {
        public string Id;
        public int Price;
        public string Name;
        public Sprite Icon;
        public UniqueId SkinId;
    }
}