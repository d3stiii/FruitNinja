using CodeBase.Data.Persistent;
using CodeBase.Extensions;
using UnityEditor;
using UnityEngine;

namespace CodeBase.Editor
{
    public static class Tools
    {
        [MenuItem("Tools/Clear Prefs")]
        public static void ClearPrefs()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }

        [MenuItem("Tools/Reset Skins")]
        public static void ResetSkins()
        {
            var data = PlayerPrefs.GetString("Data").ToDeserialized<PersistentData>();
            data.PurchaseData.BoughtItemIds.Clear();
            data.SkinsData.SelectedSkinId = data.SkinsData.OwnedSkinIds[0];
            data.SkinsData.OwnedSkinIds.RemoveRange(1, data.SkinsData.OwnedSkinIds.Count - 1);
            PlayerPrefs.SetString("Data", data.ToJson());
            PlayerPrefs.Save();
        }

        [MenuItem("Tools/Get Coins")]
        public static void GetCoins()
        {
            var data = PlayerPrefs.GetString("Data").ToDeserialized<PersistentData>();
            data.CreditsData.AddCredits(999999);
            PlayerPrefs.SetString("Data", data.ToJson());
            PlayerPrefs.Save();
        }
    }
}