using CodeBase.UI;
using CodeBase.UI.Screens;
using UnityEngine;

namespace CodeBase.Services.UI
{
    public interface IScreenService
    {
        TScreen Show<TScreen>() where TScreen : BaseScreen;
        void HideCurrentScreen();
    }

    public class ScreenService : IScreenService
    {
        private readonly IUIFactory _uiFactory;
        private BaseScreen _currentScreen;

        public ScreenService(IUIFactory uiFactory) =>
            _uiFactory = uiFactory;

        public TScreen Show<TScreen>() where TScreen : BaseScreen
        {
            if (_currentScreen != null)
                HideCurrentScreen();

            var newScreen = _uiFactory.CreateScreen<TScreen>();
            _currentScreen = newScreen;

            return newScreen;
        }

        public void HideCurrentScreen() =>
            Object.Destroy(_currentScreen.gameObject);
    }
}