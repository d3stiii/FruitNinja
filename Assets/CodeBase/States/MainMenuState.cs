using CodeBase.Services.UI;
using CodeBase.UI;

namespace CodeBase.States
{
    public class MainMenuState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly IScreenService _screenService;

        public MainMenuState(StateMachine stateMachine, IScreenService screenService)
        {
            _stateMachine = stateMachine;
            _screenService = screenService;
        }

        public void Enter()
        {
            _screenService.Show<MainMenuScreen>();
        }

        public void Exit() { }
    }
}