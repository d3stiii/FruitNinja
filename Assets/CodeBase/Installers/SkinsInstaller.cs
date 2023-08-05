using CodeBase.Services.Skins;
using Zenject;

namespace CodeBase.Installers
{
    public class SkinsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindBladeFactory();
            BindSkinsService();
        }

        private void BindBladeFactory() =>
            Container
                .Bind<IBladeFactory>()
                .To<BladeFactory>()
                .AsSingle();

        private void BindSkinsService() =>
            Container
                .Bind<ISkinsService>()
                .To<SkinsService>()
                .AsSingle();
    }
}