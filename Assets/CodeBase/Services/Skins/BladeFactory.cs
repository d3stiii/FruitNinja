using UnityEngine;
using Zenject;

namespace CodeBase.Services.Skins
{
    public interface IBladeFactory
    {
        Blade.Blade CreateBlade();
        void Cleanup();
    }

    public class BladeFactory : IBladeFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly ISkinsService _skinsService;
        private Blade.Blade _blade;

        public BladeFactory(IInstantiator instantiator, ISkinsService skinsService)
        {
            _instantiator = instantiator;
            _skinsService = skinsService;
        }

        public Blade.Blade CreateBlade()
        {
            _blade = _instantiator.InstantiatePrefabForComponent<Blade.Blade>(_skinsService.GetEquippedSkin().Prefab);
            return _blade;
        }

        public void Cleanup()
        {
            if (_blade == null)
                return;
            
            Object.Destroy(_blade.gameObject);
            _blade = null;
        }
    }
}