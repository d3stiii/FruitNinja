using CodeBase.Services;
using Zenject;

namespace CodeBase.Installers
{
    public class CommonInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSceneLoader();
        }

        private void BindSceneLoader() =>
            Container
                .BindInterfacesTo<SceneLoader>()
                .AsSingle();
    }
}