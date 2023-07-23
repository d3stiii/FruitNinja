﻿using System.Collections.Generic;
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
        private readonly IPersistentDataService _persistentDataService;

        public FruitObserver(ISessionDataService sessionDataService, IPersistentDataService persistentDataService)
        {
            _persistentDataService = persistentDataService;
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

        private void UpdateScore(Fruit fruit)
        {
            var scoreData = _sessionDataService.SessionData.ScoreData;
            scoreData.AddScore(fruit.ScoreCost);

            var highScoreData = _persistentDataService.PersistentData.HighScoreData;
            if (highScoreData.HighScore < scoreData.Score)
            {
                highScoreData.ChangeScore(scoreData.Score);
            }
        }

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