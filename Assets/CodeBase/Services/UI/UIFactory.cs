using CodeBase.UI;
using CodeBase.UI.Screens;
using Zenject;
using Object = UnityEngine.Object;

namespace CodeBase.Services.UI
{
    public interface IUIFactory
    {
        TScreen CreateScreen<TScreen>() where TScreen : BaseScreen;
        Hud GetOrCreateHud();
    }

    public class UIFactory : IUIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IUIProvider _uiProvider;
        private UIRoot _uiRoot;
        private Hud _hud;

        public UIFactory(IInstantiator instantiator, IUIProvider uiProvider)
        {
            _instantiator = instantiator;
            _uiProvider = uiProvider;
        }

        public TScreen CreateScreen<TScreen>() where TScreen : BaseScreen
        {
            var screenPrefab = _uiProvider.GetScreenPrefab<TScreen>();
            return _instantiator.InstantiatePrefabForComponent<TScreen>(screenPrefab, GetOrCreateUIRoot().transform);
        }

        public UIRoot GetOrCreateUIRoot()
        {
            if (_uiRoot == null)
                _uiRoot = Object.Instantiate(_uiProvider.GetUIRootPrefab());

            return _uiRoot;
        }

        public Hud GetOrCreateHud()
        {
            if (_hud == null)
            {
                _hud = _instantiator.InstantiatePrefabForComponent<Hud>(_uiProvider.GetHudPrefab(),
                    GetOrCreateUIRoot().transform);
            }

            return _hud;
        }
    }
}