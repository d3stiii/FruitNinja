using CodeBase.Blades;
using UnityEngine.SceneManagement;
using Zenject;

namespace CodeBase.Services.Skins
{
    public interface IBladeFactory
    {
        Blade CreateBlade();
    }

    public class BladeFactory : IBladeFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly ISkinsService _skinsService;

        public BladeFactory(IInstantiator instantiator, ISkinsService skinsService)
        {
            _instantiator = instantiator;
            _skinsService = skinsService;
        }

        public Blade CreateBlade()
        {
            var blade = _instantiator.InstantiatePrefabForComponent<Blade>(_skinsService.GetEquippedSkin().Prefab);
            SceneManager.MoveGameObjectToScene(blade.gameObject, SceneManager.GetActiveScene());
            return blade;
        }
    }
}