using System;
using CodeBase.StaticData;
using UnityEditor;
using UnityEngine;

namespace CodeBase.Editor
{
    [CustomEditor(typeof(SkinData))]
    public class SkinDataEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            SkinData itemsData = (SkinData)target;

            if (GUILayout.Button("Generate id"))
            {
                itemsData.Id = Guid.NewGuid().ToString();
            }
        }
    }
}