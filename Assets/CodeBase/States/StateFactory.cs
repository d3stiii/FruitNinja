using Zenject;

namespace CodeBase.States
{
    public interface IStateFactory
    {
        IExitableState CreateState<TState>() where TState : IExitableState;
    }

    public class StateFactory : IStateFactory
    {
        private readonly IInstantiator _instantiator;

        public StateFactory(IInstantiator instantiator) =>
            _instantiator = instantiator;

        public IExitableState CreateState<TState>() where TState : IExitableState =>
            _instantiator.Instantiate<TState>();
    }
}