using CodeBase.Data.Persistent;
using CodeBase.Extensions;
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

        public SaveLoadService(IPersistentDataService persistentDataService)
        {
            _persistentDataService = persistentDataService;
        }

        public void Save()
        {
            var dataJson = _persistentDataService.PersistentData.ToJson();
            PlayerPrefs.SetString(PrefsKey, dataJson);
        }

        public void Load()
        {
            var data = PlayerPrefs.GetString(PrefsKey).ToDeserialized<PersistentData>();
            _persistentDataService.PersistentData = data ?? new PersistentData();
        }
    }
}