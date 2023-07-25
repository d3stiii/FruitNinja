using System;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Fruits
{
    public class Fruit : MonoBehaviour
    {
        public event Action Dropped;
        public event Action<FruitData> Sliced;

        private FruitData _fruitData;

        public FruitType Type => _fruitData.Type;

        public void Initialize(FruitData fruitData) => _fruitData = fruitData;

        public void NotifySlice() => Sliced?.Invoke(_fruitData);
        public void NotifyDrop() => Dropped?.Invoke();
    }
}