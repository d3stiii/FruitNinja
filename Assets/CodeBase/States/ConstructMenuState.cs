using CodeBase.Services.UI;

namespace CodeBase.States
{
    public class ConstructMenuState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly IScreenFactory _screenFactory;

        public ConstructMenuState(StateMachine stateMachine, IScreenFactory screenFactory)
        {
            _stateMachine = stateMachine;
            _screenFactory = screenFactory;
        }

        public void Enter()
        {
            _screenFactory.CreateUIRoot();
            _stateMachine.EnterState<MainMenuState>();
        }

        public void Exit() { }
    }
}