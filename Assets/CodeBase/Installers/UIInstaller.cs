using System.Collections.Generic;
using CodeBase.Services.UI;
using CodeBase.UI;
using UnityEngine;
using Zenject;

namespace CodeBase.Installers
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private UIRoot _uiRoot;
        [SerializeField] private List<BaseScreen> _screens;

        public override void InstallBindings()
        {
            BindScreenProvider();
            BindScreenFactory();
            BindScreenService();
        }

        private void BindScreenService() =>
            Container
                .Bind<IScreenService>()
                .To<ScreenService>()
                .AsSingle();

        private void BindScreenFactory() =>
            Container
                .Bind<IScreenFactory>()
                .To<ScreenFactory>()
                .AsSingle();

        private void BindScreenProvider()
        {
            var screenProvider = new ScreenProvider(_screens, _uiRoot);
            Container
                .Bind<IScreenProvider>()
                .To<ScreenProvider>()
                .FromInstance(screenProvider)
                .AsSingle();
        }
    }
}