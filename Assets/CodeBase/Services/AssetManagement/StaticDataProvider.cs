using CodeBase.StaticData;
using Zenject;

namespace CodeBase.Services.AssetManagement
{
    public interface IStaticDataProvider
    {
        public FruitSpawnerSettings GetFruitSpawnerSettings();
    }

    public class StaticDataProvider : IStaticDataProvider, IInitializable
    {
        private const string FruitSpawnerSettingsPath = "StaticData/Fruits/FruitSpawnerSettings";
        private readonly IAssetLoader _assetLoader;
        private FruitSpawnerSettings _fruitSpawnerSettings;

        public StaticDataProvider(IAssetLoader assetLoader) =>
            _assetLoader = assetLoader;

        public void Initialize() =>
            _fruitSpawnerSettings = _assetLoader.LoadAsset<FruitSpawnerSettings>(FruitSpawnerSettingsPath);

        public FruitSpawnerSettings GetFruitSpawnerSettings() =>
            _fruitSpawnerSettings;
    }
}