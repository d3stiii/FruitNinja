using CodeBase.Services.UI;

namespace CodeBase.States
{
    public class ConstructGameState : IState
    {
        private readonly IScreenFactory _screenFactory;
        private readonly StateMachine _stateMachine;

        public ConstructGameState(StateMachine stateMachine, IScreenFactory screenFactory)
        {
            _screenFactory = screenFactory;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            var uiRoot = _screenFactory.GetOrCreateUIRoot();
            _stateMachine.EnterState<GameplayState>();
        }

        public void Exit() { }
    }
}