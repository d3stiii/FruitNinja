using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.UI;

namespace CodeBase.Services.UI
{
    public interface IScreenProvider
    {
        TScreen GetScreenPrefab<TScreen>() where TScreen : BaseScreen;
        UIRoot GetUIRootPrefab();
    }

    public class ScreenProvider : IScreenProvider
    {
        private readonly Dictionary<Type, BaseScreen> _screenPrefabs;
        private readonly UIRoot _uiRootPrefab;

        public ScreenProvider(IEnumerable<BaseScreen> screens, UIRoot uiRootPrefab)
        {
            _uiRootPrefab = uiRootPrefab;
            _screenPrefabs = screens.ToDictionary(screen => screen.GetType(), screen => screen);
        }

        public TScreen GetScreenPrefab<TScreen>() where TScreen : BaseScreen =>
            _screenPrefabs.TryGetValue(typeof(TScreen), out var screen) ? (TScreen)screen : null;

        public UIRoot GetUIRootPrefab() =>
            _uiRootPrefab;
    }
}