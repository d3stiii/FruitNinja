using System.Collections.Generic;
using System.Linq;
using CodeBase.Fruits;
using CodeBase.StaticData;
using UnityEngine;
using Zenject;

namespace CodeBase.Services.AssetManagement
{
    public interface IStaticDataProvider
    {
        public FruitSpawnerSettings GetFruitSpawnerSettings();
        public FruitData GetFruitData(FruitType fruitType);
    }

    public class StaticDataProvider : IStaticDataProvider, IInitializable
    {
        private const string FruitSpawnerSettingsPath = "StaticData/Fruits/FruitSpawnerSettings";
        private const string FruitsDataPath = "StaticData/Fruits";
        private readonly IAssetLoader _assetLoader;
        private FruitSpawnerSettings _fruitSpawnerSettings;
        private Dictionary<FruitType, FruitData> _fruitsData;

        public StaticDataProvider(IAssetLoader assetLoader) =>
            _assetLoader = assetLoader;

        public void Initialize()
        {
            _fruitSpawnerSettings = _assetLoader.LoadAsset<FruitSpawnerSettings>(FruitSpawnerSettingsPath);
            _fruitsData = Resources.LoadAll<FruitData>(FruitsDataPath)
                .ToDictionary(fruit => fruit.Type, fruit => fruit);
        }

        public FruitData GetFruitData(FruitType fruitType) =>
            _fruitsData.TryGetValue(fruitType, out var data) ? data : null;

        public FruitSpawnerSettings GetFruitSpawnerSettings() =>
            _fruitSpawnerSettings;
    }
}