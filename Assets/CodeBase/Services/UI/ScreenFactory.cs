using System;
using CodeBase.UI;
using Zenject;
using Object = UnityEngine.Object;

namespace CodeBase.Services.UI
{
    public interface IScreenFactory
    {
        TScreen CreateScreen<TScreen>() where TScreen : BaseScreen;
        UIRoot GetOrCreateUIRoot();
    }

    public class ScreenFactory : IScreenFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IScreenProvider _screenProvider;
        private UIRoot _uiRoot;

        public ScreenFactory(IInstantiator instantiator, IScreenProvider screenProvider)
        {
            _instantiator = instantiator;
            _screenProvider = screenProvider;
        }

        public TScreen CreateScreen<TScreen>() where TScreen : BaseScreen
        {
            if (_uiRoot == null)
            {
                throw new NullReferenceException(
                    $"UI root shouldn't be null. Call {nameof(GetOrCreateUIRoot)} method to create UI root.");
            }

            var screenPrefab = _screenProvider.GetScreenPrefab<TScreen>();
            return _instantiator.InstantiatePrefabForComponent<TScreen>(screenPrefab, _uiRoot.transform);
        }

        public UIRoot GetOrCreateUIRoot()
        {
            if (_uiRoot == null)
                _uiRoot = Object.Instantiate(_screenProvider.GetUIRootPrefab());

            return _uiRoot;
        }
    }
}