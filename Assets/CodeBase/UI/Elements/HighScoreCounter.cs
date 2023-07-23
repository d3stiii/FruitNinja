using System;
using CodeBase.Services.Data;
using TMPro;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Elements
{
    public class HighScoreCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _counter;
        private IPersistentDataService _persistentDataService;

        private void Awake() => 
            UpdateCounter();

        [Inject]
        public void Construct(IPersistentDataService persistentDataService)
        {
            _persistentDataService = persistentDataService;
            _persistentDataService.PersistentData.HighScoreData.Changed += UpdateCounter;
        }

        private void OnDestroy() => 
            _persistentDataService.PersistentData.HighScoreData.Changed -= UpdateCounter;

        private void UpdateCounter()
        {
            _counter.text = $"Best: {_persistentDataService.PersistentData.HighScoreData.HighScore}";
        }
    }
}