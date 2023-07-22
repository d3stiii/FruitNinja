using System.Collections.Generic;
using CodeBase.Fruits;
using CodeBase.Services.Data;

namespace CodeBase.Services.Fruits
{
    public interface IFruitObserver
    {
        void SubscribeUpdates(Fruit fruit);
        void Cleanup();
    }

    public class FruitObserver : IFruitObserver
    {
        private readonly ISessionDataService _sessionDataService;
        private readonly List<Fruit> _fruits = new();

        public FruitObserver(ISessionDataService sessionDataService)
        {
            _sessionDataService = sessionDataService;
        }

        public void SubscribeUpdates(Fruit fruit)
        {
            if (_fruits.Contains(fruit))
                return;

            fruit.Sliced += UpdateScore;
            fruit.Dropped += SpendAttempt;

            _fruits.Add(fruit);
        }

        private void SpendAttempt() =>
            _sessionDataService.SessionData.AttemptsData.SpendAttempts();

        private void UpdateScore(Fruit fruit) =>
            _sessionDataService.SessionData.ScoreData.AddScore(fruit.ScoreCost);

        public void Cleanup()
        {
            foreach (var fruit in _fruits)
            {
                fruit.Dropped -= SpendAttempt;
                fruit.Sliced -= UpdateScore;
            }

            _fruits.Clear();
        }
    }
}