using Zenject;

namespace CodeBase.States
{
    public interface IStateFactory
    {
        IExitableState CreateState<T>() where T : IExitableState;
    }

    public class StateFactory : IStateFactory
    {
        private readonly IInstantiator _instantiator;

        public StateFactory(IInstantiator instantiator) =>
            _instantiator = instantiator;

        public IExitableState CreateState<T>() where T : IExitableState =>
            _instantiator.Instantiate<T>();
    }
}