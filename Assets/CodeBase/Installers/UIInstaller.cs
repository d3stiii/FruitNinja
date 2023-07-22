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
        [SerializeField] private Hud _hud;
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
                .Bind<IUIFactory>()
                .To<UIFactory>()
                .AsSingle();

        private void BindScreenProvider()
        {
            var screenProvider = new UIProvider(_screens, _uiRoot, _hud);
            Container
                .Bind<IUIProvider>()
                .To<UIProvider>()
                .FromInstance(screenProvider)
                .AsSingle();
        }
    }
}