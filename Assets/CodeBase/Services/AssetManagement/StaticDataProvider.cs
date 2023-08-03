using System.Collections.Generic;
using System.Linq;
using CodeBase.Fruits;
using CodeBase.StaticData;
using Zenject;

namespace CodeBase.Services.AssetManagement
{
    public interface IStaticDataProvider
    {
        FruitSpawnerSettings GetFruitSpawnerSettings();
        FruitData GetFruitData(FruitType fruitType);
        SkinShopItemsData GetShopItemsData();
    }

    public class StaticDataProvider : IStaticDataProvider, IInitializable
    {
        private const string FruitSpawnerSettingsPath = "StaticData/Fruits/FruitSpawnerSettings";
        private const string FruitsDataPath = "StaticData/Fruits";
        private const string SkinShopItemsDataPath = "StaticData/Shop/SkinShopItemsData";

        private readonly IAssetLoader _assetLoader;
        private FruitSpawnerSettings _fruitSpawnerSettings;
        private Dictionary<FruitType, FruitData> _fruitsData;
        private SkinShopItemsData _shopItemsData;

        public StaticDataProvider(IAssetLoader assetLoader) =>
            _assetLoader = assetLoader;

        public void Initialize()
        {
            _fruitSpawnerSettings = _assetLoader.LoadAsset<FruitSpawnerSettings>(FruitSpawnerSettingsPath);
            _fruitsData = _assetLoader.LoadAllAssets<FruitData>(FruitsDataPath)
                .ToDictionary(fruit => fruit.Type, fruit => fruit);
            _shopItemsData = _assetLoader.LoadAsset<SkinShopItemsData>(SkinShopItemsDataPath);
        }

        public FruitData GetFruitData(FruitType fruitType) =>
            _fruitsData.TryGetValue(fruitType, out var data) ? data : null;

        public FruitSpawnerSettings GetFruitSpawnerSettings() =>
            _fruitSpawnerSettings;

        public SkinShopItemsData GetShopItemsData() =>
            _shopItemsData;
    }
}