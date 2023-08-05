using System;
using CodeBase.Services.Shop.Skins;
using CodeBase.StaticData;
using UnityEditor;
using UnityEngine;

namespace CodeBase.Editor
{
    [CustomEditor(typeof(SkinShopItemsData))]
    public class SkinShopItemsDataEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            SkinShopItemsData itemsData = (SkinShopItemsData)target;

            if (GUILayout.Button("Add item with unique id"))
            {
                var item = new SkinShopItemDescription
                {
                    Id = Guid.NewGuid().ToString()
                };
                itemsData.ShopItems.Add(item);
            }
        }
    }
}