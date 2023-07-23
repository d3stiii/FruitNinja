using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.UI;
using CodeBase.UI.Screens;

namespace CodeBase.Services.UI
{
    public interface IUIProvider
    {
        TScreen GetScreenPrefab<TScreen>() where TScreen : BaseScreen;
        UIRoot GetUIRootPrefab();
        Hud GetHudPrefab();
    }

    public class UIProvider : IUIProvider
    {
        private readonly Dictionary<Type, BaseScreen> _screenPrefabs;
        private readonly Hud _hudPrefab;
        private readonly UIRoot _uiRootPrefab;

        public UIProvider(IEnumerable<BaseScreen> screens, UIRoot uiRootPrefab, Hud hudPrefab)
        {
            _uiRootPrefab = uiRootPrefab;
            _screenPrefabs = screens.ToDictionary(screen => screen.GetType(), screen => screen);
            _hudPrefab = hudPrefab;
        }

        public TScreen GetScreenPrefab<TScreen>() where TScreen : BaseScreen =>
            _screenPrefabs.TryGetValue(typeof(TScreen), out var screen) ? (TScreen)screen : null;

        public UIRoot GetUIRootPrefab() =>
            _uiRootPrefab;

        public Hud GetHudPrefab() =>
            _hudPrefab;
    }
}