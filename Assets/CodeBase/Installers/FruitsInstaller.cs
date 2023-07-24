using CodeBase.Services.Fruits;
using Zenject;

namespace CodeBase.Installers
{
    public class FruitsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFruitFactory();
            BindFruitSpawner();
            BindFruitObserver();
            BindAttemptsObserver();
        }

        private void BindFruitObserver() =>
            Container
                .Bind<IFruitObserver>()
                .To<FruitObserver>()
                .AsSingle();

        private void BindFruitFactory() =>
            Container
                .Bind<IFruitFactory>()
                .To<FruitFactory>()
                .AsSingle();

        private void BindFruitSpawner() =>
            Container
                .BindInterfacesTo<FruitSpawner>()
                .AsSingle();

        private void BindAttemptsObserver() =>
            Container
                .Bind<IAttemptsObserver>()
                .To<AttemptsObserver>()
                .AsSingle();
    }
}