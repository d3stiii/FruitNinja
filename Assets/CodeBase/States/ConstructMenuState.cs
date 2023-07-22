using CodeBase.Services.UI;

namespace CodeBase.States
{
    public class ConstructMenuState : IState
    {
        private readonly IUIFactory _uiFactory;
        private readonly StateMachine _stateMachine;

        public ConstructMenuState(StateMachine stateMachine, IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _uiFactory.GetOrCreateUIRoot();
            _stateMachine.EnterState<MainMenuState>();
        }

        public void Exit() { }
    }
}