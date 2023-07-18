using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Services.UI
{
    public interface IScreenProvider
    {
        TScreen GetScreen<TScreen>() where TScreen : BaseScreen;
        GameObject GetUIRoot();
    }

    public class ScreenProvider : IScreenProvider
    {
        private readonly Dictionary<Type, BaseScreen> _screens;
        private readonly GameObject _uiRoot;

        public ScreenProvider(IEnumerable<BaseScreen> screens, GameObject uiRoot)
        {
            _uiRoot = uiRoot;
            _screens = screens.ToDictionary(screen => screen.GetType(), screen => screen);
        }

        public TScreen GetScreen<TScreen>() where TScreen : BaseScreen =>
            _screens.TryGetValue(typeof(TScreen), out var screen) ? (TScreen)screen : null;

        public GameObject GetUIRoot() =>
            _uiRoot;
    }
}