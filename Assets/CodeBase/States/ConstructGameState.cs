using CodeBase.Services.UI;

namespace CodeBase.States
{
    public class ConstructGameState : IState
    {
        private readonly IScreenFactory _screenFactory;
        private readonly StateMachine _stateMachine;

        public ConstructGameState(IScreenFactory screenFactory, StateMachine stateMachine)
        {
            _screenFactory = screenFactory;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _screenFactory.CreateUIRoot();
            _stateMachine.EnterState<GameplayState>();
        }

        public void Exit() { }
    }
}