using CodeBase.Services;
using CodeBase.Services.AssetManagement;
using CodeBase.Utilities;
using UnityEngine;
using Zenject;

namespace CodeBase.Installers
{
    public class CommonInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineRunner _coroutineRunner;

        public override void InstallBindings()
        {
            BindCoroutineRunner();
            BindSceneLoader();
            BindAssetLoader();
            BindStaticDataProvider();
        }

        private void BindCoroutineRunner() =>
            Container
                .Bind<ICoroutineRunner>()
                .To<CoroutineRunner>()
                .FromInstance(_coroutineRunner);

        private void BindSceneLoader() =>
            Container
                .BindInterfacesTo<SceneLoader>()
                .AsSingle();

        private void BindAssetLoader()
        {
            Container
                .BindInterfacesTo<AssetLoader>()
                .AsSingle();
        }

        private void BindStaticDataProvider()
        {
            Container
                .BindInterfacesTo<StaticDataProvider>()
                .AsSingle();
        }
    }
}