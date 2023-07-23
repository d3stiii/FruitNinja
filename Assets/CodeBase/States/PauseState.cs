using CodeBase.Services.Pause;
using CodeBase.Services.UI;
using CodeBase.UI;
using CodeBase.UI.Screens;

namespace CodeBase.States
{
    public class PauseState : IState
    {
        private readonly IScreenService _screenService;
        private readonly IPauseService _pauseService;

        public PauseState(IScreenService screenService, IPauseService pauseService)
        {
            _screenService = screenService;
            _pauseService = pauseService;
        }

        public void Enter()
        {
            _pauseService.Pause();
            _screenService.Show<PauseScreen>();
        }

        public void Exit()
        {
            _pauseService.Unpause();
            _screenService.HideCurrentScreen();
        }
    }
}