using CodeBase.Services.UI;
using CodeBase.UI.Screens;

namespace CodeBase.States
{
    public class MainMenuState : IState
    {
        private readonly IScreenService _screenService;

        public MainMenuState(IScreenService screenService)
        {
            _screenService = screenService;
        }

        public void Enter() =>
            _screenService.Show<MainMenuScreen>();

        public void Exit() { }
    }
}