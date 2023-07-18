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

        public void EnterState<T>() where T : class, IState
        {
            IState newState = ChangeState<T>();
            newState.Enter();
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