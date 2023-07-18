namespace CodeBase.States
{
    public class StateMachine
    {
        private readonly IStateFactory _stateFactory;
        private IExitableState _currentState;

        public StateMachine(IStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        public void EnterState<TState>() where TState : class, IState
        {
            IState newState = ChangeState<TState>();
            newState.Enter();
        }

        public void EnterState<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            IPayloadedState<TPayload> newState = ChangeState<TState>();
            newState.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();

            var state = GetState<TState>();
            _currentState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _stateFactory.CreateState<TState>() as TState;
    }
}