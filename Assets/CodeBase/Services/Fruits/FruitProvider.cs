using System.Collections.Generic;
using System.Linq;
using CodeBase.Fruits;

namespace CodeBase.Services.Fruits
{
    public interface IFruitProvider
    {
        SpawnerRoot GetSpawnerRootPrefab();
        Fruit GetFruitPrefab(FruitType fruitType);
    }

    public class FruitProvider : IFruitProvider
    {
        private readonly SpawnerRoot _spawnerRootPrefab;
        private readonly Dictionary<FruitType, Fruit> _fruits;

        public FruitProvider(IEnumerable<Fruit> fruitPrefabs, SpawnerRoot spawnerRootPrefab)
        {
            _spawnerRootPrefab = spawnerRootPrefab;
            _fruits = fruitPrefabs.ToDictionary(fruit => fruit.Type, fruit => fruit);
        }

        public SpawnerRoot GetSpawnerRootPrefab() => 
            _spawnerRootPrefab;

        public Fruit GetFruitPrefab(FruitType fruitType) =>
            _fruits.TryGetValue(fruitType, out var fruit) ? fruit : null;
    }
}