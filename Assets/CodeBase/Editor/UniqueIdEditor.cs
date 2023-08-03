using System;
using System.Linq;
using CodeBase.Logic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace CodeBase.Editor
{
    [CustomEditor(typeof(UniqueId))]
    public class UniqueIdEditor : UnityEditor.Editor
    {
        private void OnEnable()
        {
            var uniqueId = (UniqueId)target;

            if (string.IsNullOrEmpty(uniqueId.Id))
            {
                Generate(uniqueId);
            }
            else
            {
                var ids = FindObjectsOfType<UniqueId>();
                if (ids.Any(other => other != uniqueId && other.Id == uniqueId.Id))
                {
                    Generate(uniqueId);
                }
            }
        }


        private void Generate(UniqueId uniqueId)
        {
            uniqueId.Id = Guid.NewGuid().ToString();
            if (Application.isEditor)
            {
                EditorUtility.SetDirty(uniqueId);
                EditorSceneManager.MarkSceneDirty(uniqueId.gameObject.scene);
            }
        }
    }
}