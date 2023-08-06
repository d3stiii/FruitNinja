using System.Collections.Generic;
using System.Linq;
using CodeBase.AssetManagement;
using CodeBase.Fruits;
using CodeBase.StaticData;
using Zenject;

namespace CodeBase.Services.AssetManagement
{
    public interface IStaticDataProvider
    {
        ThrowableSpawnerSettings GetFruitSpawnerSettings();
        ThrowableSpawnerSettings GetBombSpawnerSettings();
        FruitData GetFruitData(FruitType fruitType);
        SkinShopItemsData GetShopItemsData();
        SkinsData GetSkinsData();
    }

    public class StaticDataProvider : IStaticDataProvider, IInitializable
    {
        private readonly IAssetLoader _assetLoader;
        private ThrowableSpawnerSettings _fruitSpawnerSettings;
        private ThrowableSpawnerSettings _bombSpawnerSettings;
        private Dictionary<FruitType, FruitData> _fruitsData;
        private SkinShopItemsData _shopItemsData;
        private SkinsData _skinsData;

        public StaticDataProvider(IAssetLoader assetLoader) =>
            _assetLoader = assetLoader;

        public void Initialize()
        {
            _fruitSpawnerSettings =
                _assetLoader.LoadAsset<ThrowableSpawnerSettings>(AssetsPath.FruitSpawnerSettingsPath);
            _fruitsData = _assetLoader.LoadAllAssets<FruitData>(AssetsPath.FruitsDataPath)
                .ToDictionary(fruit => fruit.Type, fruit => fruit);
            _shopItemsData = _assetLoader.LoadAsset<SkinShopItemsData>(AssetsPath.SkinShopItemsDataPath);
            _skinsData = _assetLoader.LoadAsset<SkinsData>(AssetsPath.SkinsDataPath);
            _bombSpawnerSettings = _assetLoader.LoadAsset<ThrowableSpawnerSettings>(AssetsPath.BombSpawnerSettingsPath);
        }

        public FruitData GetFruitData(FruitType fruitType) =>
            _fruitsData.TryGetValue(fruitType, out var data) ? data : null;

        public ThrowableSpawnerSettings GetBombSpawnerSettings() =>
            _bombSpawnerSettings;

        public ThrowableSpawnerSettings GetFruitSpawnerSettings() =>
            _fruitSpawnerSettings;

        public SkinShopItemsData GetShopItemsData() =>
            _shopItemsData;

        public SkinsData GetSkinsData() =>
            _skinsData;
    }
}