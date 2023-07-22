using System.Collections.Generic;
using CodeBase.Fruits;
using CodeBase.Services.Fruits;
using UnityEngine;
using Zenject;

namespace CodeBase.Installers
{
    public class FruitsInstaller : MonoInstaller
    {
        [SerializeField] private List<Fruit> _fruits;
        [SerializeField] private SpawnerRoot _spawnerRoot;

        public override void InstallBindings()
        {
            BindFruitProvider();
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

        private void BindFruitProvider()
        {
            var fruitProvider = new FruitProvider(_fruits, _spawnerRoot);
            Container
                .Bind<IFruitProvider>()
                .To<FruitProvider>()
                .FromInstance(fruitProvider)
                .AsSingle();
        }

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