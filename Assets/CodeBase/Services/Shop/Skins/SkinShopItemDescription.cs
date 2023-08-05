using System;
using CodeBase.StaticData;

namespace CodeBase.Services.Shop.Skins
{
    [Serializable]
    public class SkinShopItemDescription
    {
        public string Id;
        public int Price;
        public SkinData Skin;
    }
}