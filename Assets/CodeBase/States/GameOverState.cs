using CodeBase.Services.Pause;
using CodeBase.Services.SaveLoad;
using CodeBase.Services.UI;
using CodeBase.UI;
using CodeBase.UI.Screens;

namespace CodeBase.States
{
    public class GameOverState : IState
    {
        private readonly IScreenService _screenService;
        private readonly IPauseService _pauseService;
        private readonly ISaveLoadService _saveLoadService;

        public GameOverState(IScreenService screenService, IPauseService pauseService, ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
            _screenService = screenService;
            _pauseService = pauseService;
        }

        public void Enter()
        {
            _saveLoadService.Save();
            _pauseService.Pause();
            _screenService.Show<GameOverScreen>();
        }

        public void Exit() =>
            _pauseService.Unpause();
    }
}