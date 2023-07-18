using CodeBase.Services;
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
            BindSceneLoader();
            BindCoroutineRunner();
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
    }
}