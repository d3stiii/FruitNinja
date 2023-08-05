using CodeBase.Services.Skins;
using Zenject;

namespace CodeBase.Installers
{
    public class SkinsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSkinsService();
        }

        private void BindSkinsService() =>
            Container
                .Bind<ISkinsService>()
                .To<SkinsService>()
                .AsSingle();
    }
}