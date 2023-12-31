using CodeBase.Services;
using CodeBase.Services.AssetManagement;
using CodeBase.Services.Input;
using CodeBase.Services.Pause;
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
            BindPauseService();
            BindInputService();
        }

        private void BindInputService()
        {
            IInputService inputService =
                Application.isMobilePlatform ? new MobileInputService() : new StandaloneInputService();
            Container.Bind<IInputService>().FromInstance(inputService);
        }

        private void BindPauseService() =>
            Container
                .Bind<IPauseService>()
                .To<PauseService>()
                .AsSingle();

        private void BindCoroutineRunner() =>
            Container
                .Bind<ICoroutineRunner>()
                .To<CoroutineRunner>()
                .FromInstance(_coroutineRunner);

        private void BindSceneLoader() =>
            Container
                .Bind<ISceneLoader>()
                .To<SceneLoader>()
                .AsSingle();

        private void BindAssetLoader() =>
            Container
                .Bind<IAssetLoader>()
                .To<AssetLoader>()
                .AsSingle();
    }
}