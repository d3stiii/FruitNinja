using CodeBase.Fruits;
using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "FruitData", menuName = "Fruits/FruitData")]
    public class FruitData : ScriptableObject
    {
        [SerializeField] private Fruit _prefab;
        [SerializeField] private FruitType _type;
        [SerializeField] private int _cost;

        public FruitType Type => _type;
        public int Cost => _cost;

        public Fruit Prefab => _prefab;
    }
}