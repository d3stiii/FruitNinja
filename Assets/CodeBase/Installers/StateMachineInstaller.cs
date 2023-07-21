using CodeBase.Services.States;
using CodeBase.States;
using Zenject;

namespace CodeBase.Installers
{
    public class StateMachineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindStateFactory();
            BindStateMachine();
        }

        private void BindStateMachine() =>
            Container
                .Bind<StateMachine>()
                .AsSingle();

        private void BindStateFactory() =>
            Container
                .Bind<IStateFactory>()
                .To<StateFactory>()
                .AsSingle();
    }
}