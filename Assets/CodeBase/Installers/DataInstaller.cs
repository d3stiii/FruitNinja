using CodeBase.Services.Data;
using CodeBase.Services.SaveLoad;
using Zenject;

namespace CodeBase.Installers
{
    public class DataInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSessionDataService();
            BindPersistentDataService();
            BindSaveLoadService();
        }

        private void BindSaveLoadService() =>
            Container
                .Bind<ISaveLoadService>()
                .To<SaveLoadService>()
                .AsSingle();

        private void BindPersistentDataService() =>
            Container
                .Bind<IPersistentDataService>()
                .To<PersistentDataService>()
                .AsSingle();

        private void BindSessionDataService() =>
            Container
                .Bind<ISessionDataService>()
                .To<SessionDataService>()
                .AsSingle();
    }
}