using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "SkinsData", menuName = "Skins/SkinsData")]
    public class SkinsData : ScriptableObject
    {
        [SerializeField] private SkinData _defaultSkin;
        [SerializeField] private List<SkinData> _skins;

        public SkinData DefaultSkin => _defaultSkin;
        public List<SkinData> Skins => _skins;

        private void OnValidate()
        {
            if (!_skins.Contains(_defaultSkin))
            {
                _skins.Add(_defaultSkin);
            }
        }
    }
}