using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "SkinData", menuName = "Skins/SkinData")]
    public class SkinData : ScriptableObject
    {
        public string Id;

        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Blade.Blade _prefab;

        public Sprite Icon => _icon;
        public string Name => _name;
        public Blade.Blade Prefab => _prefab;
    }
}