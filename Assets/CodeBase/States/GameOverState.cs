using CodeBase.Services.Data;
using CodeBase.Services.Pause;
using CodeBase.Services.SaveLoad;
using CodeBase.Services.UI;
using CodeBase.UI.Screens;

namespace CodeBase.States
{
    public class GameOverState : IState
    {
        private readonly IScreenService _screenService;
        private readonly IPauseService _pauseService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IPersistentDataService _persistentDataService;
        private readonly ISessionDataService _sessionDataService;

        public GameOverState(IScreenService screenService, IPauseService pauseService, ISaveLoadService saveLoadService,
            IPersistentDataService persistentDataService, ISessionDataService sessionDataService)
        {
            _saveLoadService = saveLoadService;
            _persistentDataService = persistentDataService;
            _sessionDataService = sessionDataService;
            _screenService = screenService;
            _pauseService = pauseService;
        }

        public void Enter()
        {
            UpdateData();
            _saveLoadService.Save();
            _pauseService.Pause();
            _screenService.Show<GameOverScreen>();
        }

        private void UpdateData()
        {
            var score = _sessionDataService.SessionData.ScoreData.Value;
            _persistentDataService.PersistentData.CreditsData.AddCredits(score);
            _persistentDataService.PersistentData.HighScoreData.ChangeScore(score);
        }

        public void Exit() =>
            _pauseService.Unpause();
    }
}