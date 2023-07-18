using CodeBase.UI;
using UnityEngine;
using Zenject;

namespace CodeBase.Services.UI
{
    public interface IScreenFactory
    {
        TScreen CreateScreen<TScreen>() where TScreen : BaseScreen;
        GameObject CreateUIRoot();
    }

    public class ScreenFactory : IScreenFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IScreenProvider _screenProvider;
        private Transform _uiRoot;

        public ScreenFactory(IInstantiator instantiator, IScreenProvider screenProvider)
        {
            _instantiator = instantiator;
            _screenProvider = screenProvider;
        }

        public GameObject CreateUIRoot()
        {
            if (_uiRoot != null)
                return _uiRoot.gameObject;

            var uiRootPrefab = _screenProvider.GetUIRoot();
            _uiRoot = Object.Instantiate(uiRootPrefab).transform;
            return _uiRoot.gameObject;
        }

        public TScreen CreateScreen<TScreen>() where TScreen : BaseScreen
        {
            var screenPrefab = _screenProvider.GetScreen<TScreen>();
            return _instantiator.InstantiatePrefabForComponent<TScreen>(screenPrefab, _uiRoot);
        }
    }
}