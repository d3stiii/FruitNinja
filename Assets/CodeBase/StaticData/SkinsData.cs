using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "SkinsData", menuName = "Skins/SkinsData", order = 0)]
    public class SkinsData : ScriptableObject
    {
        [SerializeField] private Blade.Blade _defaultSkin;
        [SerializeField] private List<Blade.Blade> _skins;

        public Blade.Blade DefaultSkin => _defaultSkin;
        public List<Blade.Blade> Skins => _skins;

        private void OnValidate()
        {
            if (!_skins.Contains(_defaultSkin))
            {
                _skins.Add(_defaultSkin);
            }
        }
    }
}