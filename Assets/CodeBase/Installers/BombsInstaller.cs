using CodeBase.Services.Bombs;
using Zenject;

namespace CodeBase.Installers
{
    public class BombsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindBombFactory();
            BindBombSpawner();
        }

        private void BindBombSpawner() =>
            Container
                .BindInterfacesTo<BombSpawner>()
                .AsSingle();

        private void BindBombFactory() =>
            Container
                .BindInterfacesTo<BombFactory>()
                .AsSingle();
    }
}