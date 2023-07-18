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
                .BindInterfacesAndSelfTo<StateMachine>()
                .AsSingle();

        private void BindStateFactory() =>
            Container
                .BindInterfacesTo<StateFactory>()
                .AsSingle();
    }
}