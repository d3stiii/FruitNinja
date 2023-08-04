using CodeBase.Data.Persistent;
using CodeBase.Extensions;
using CodeBase.Logic;
using CodeBase.Services.AssetManagement;
using CodeBase.Services.Data;
using UnityEngine;

namespace CodeBase.Services.SaveLoad
{
    public interface ISaveLoadService
    {
        void Save();
        void Load();
    }

    public class SaveLoadService : ISaveLoadService
    {
        private const string PrefsKey = "Data";
        private readonly IPersistentDataService _persistentDataService;
        private readonly IStaticDataProvider _staticDataProvider;

        public SaveLoadService(IPersistentDataService persistentDataService, IStaticDataProvider staticDataProvider)
        {
            _persistentDataService = persistentDataService;
            _staticDataProvider = staticDataProvider;
        }

        public void Save()
        {
            var dataJson = _persistentDataService.PersistentData.ToJson();
            PlayerPrefs.SetString(PrefsKey, dataJson);
            Debug.Log(dataJson);
        }

        public void Load()
        {
            var data = PlayerPrefs.GetString(PrefsKey).ToDeserialized<PersistentData>();
            var defaultSkin = _staticDataProvider.GetSkinsData().DefaultSkin;
            var defaultSkinId = defaultSkin.GetComponent<UniqueId>().Id;
            _persistentDataService.PersistentData = data ?? new PersistentData(defaultSkinId);
        }
    }
}