namespace CodeBase.States
{
    public class RestartState : IState
    {
        private readonly StateMachine _stateMachine;

        public RestartState(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _stateMachine.EnterState<LoadGameState>();
        }

        public void Exit() { }
    }
}