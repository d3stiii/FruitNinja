using System;
using System.Collections.Generic;
using CodeBase.Services.AssetManagement;
using CodeBase.Services.Data;
using CodeBase.Services.SaveLoad;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Services.Skins
{
    public interface ISkinsService
    {
        event Action Equipped;
        void Equip(SkinData skin);
        SkinData GetEquippedSkin();
        IEnumerable<SkinData> GetOwnedSkins();
    }

    public class SkinsService : ISkinsService
    {
        private readonly IPersistentDataService _persistentDataService;
        private readonly IStaticDataProvider _staticDataProvider;
        private readonly ISaveLoadService _saveLoadService;

        public SkinsService(IPersistentDataService persistentDataService, IStaticDataProvider staticDataProvider,
            ISaveLoadService saveLoadService)
        {
            _persistentDataService = persistentDataService;
            _staticDataProvider = staticDataProvider;
            _saveLoadService = saveLoadService;
        }

        public event Action Equipped;

        public void Equip(SkinData skin)
        {
            _persistentDataService.PersistentData.SkinsData.SelectedSkinId = skin.Id;
            Debug.Log($"{skin.Id} skin equipped");
            Equipped?.Invoke();
            _saveLoadService.Save();
        }

        public SkinData GetEquippedSkin()
        {
            var selectedSkinId = _persistentDataService.PersistentData.SkinsData.SelectedSkinId;
            var selectedSkin = _staticDataProvider.GetSkinsData().Skins.Find(skin => skin.Id == selectedSkinId);
            return selectedSkin;
        }

        public IEnumerable<SkinData> GetOwnedSkins()
        {
            var ownedSkins = _persistentDataService.PersistentData.SkinsData.OwnedSkinIds;
            foreach (var skin in _staticDataProvider.GetSkinsData().Skins)
            {
                var ownedSkin = ownedSkins.Find(id => id == skin.Id);

                if (ownedSkin == null)
                    continue;

                yield return skin;
            }
        }
    }
}