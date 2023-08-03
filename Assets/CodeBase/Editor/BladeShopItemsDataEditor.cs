using System;
using CodeBase.Services.Shop;
using CodeBase.StaticData;
using UnityEditor;
using UnityEngine;

namespace CodeBase.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(BladeShopItemsData))]
    public class BladeShopItemsDataEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            BladeShopItemsData itemsData = (BladeShopItemsData)target;

            if (GUILayout.Button("Add item with unique id"))
            {
                var item = new BladeShopItemDescription
                {
                    Id = Guid.NewGuid().ToString()
                };
                itemsData.ShopItems.Add(item);
            }
        }
    }
}