using CodeBase.Services.Data;
using Zenject;

namespace CodeBase.Installers
{
    public class DataInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSessionDataService();
        }

        private void BindSessionDataService() =>
            Container
                .Bind<ISessionDataService>()
                .To<SessionDataService>()
                .AsSingle();
    }
}