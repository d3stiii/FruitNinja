using System;
using System.Collections.Generic;
using Zenject;

namespace CodeBase.States
{
    public class StateMachine : IInitializable
    {
        private readonly IStateFactory _stateFactory;
        private Dictionary<Type, IExitableState> _states;
        private IExitableState _currentState;

        public StateMachine(IStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        public void Initialize()
        {
            _states = new Dictionary<Type, IExitableState>
            {
                { typeof(LoadMenuState), _stateFactory.CreateState<LoadMenuState>() }
            };
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
            _states[typeof(TState)] as TState;
    }
}