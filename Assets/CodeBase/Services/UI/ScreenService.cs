using CodeBase.UI;
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
        private readonly IScreenFactory _screenFactory;
        private BaseScreen _currentScreen;

        public ScreenService(IScreenFactory screenFactory)
        {
            _screenFactory = screenFactory;
        }

        public TScreen Show<TScreen>() where TScreen : BaseScreen
        {
            if (_currentScreen != null)
                HideCurrentScreen();
            
            var newScreen = _screenFactory.CreateScreen<TScreen>();
            _currentScreen = newScreen;

            return newScreen;
        }

        public void HideCurrentScreen() =>
            Object.Destroy(_currentScreen.gameObject);
    }
}