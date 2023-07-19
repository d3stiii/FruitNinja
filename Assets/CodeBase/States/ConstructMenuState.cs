using CodeBase.Services.UI;

namespace CodeBase.States
{
    public class ConstructMenuState : IState
    {
        private readonly IScreenFactory _screenFactory;
        private readonly StateMachine _stateMachine;

        public ConstructMenuState(StateMachine stateMachine, IScreenFactory screenFactory)
        {
            _screenFactory = screenFactory;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            var uiRoot = _screenFactory.GetOrCreateUIRoot();
            _stateMachine.EnterState<MainMenuState>();
        }

        public void Exit() { }
    }
}