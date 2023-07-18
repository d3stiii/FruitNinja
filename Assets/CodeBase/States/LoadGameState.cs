using CodeBase.Services;

namespace CodeBase.States
{
    public class LoadGameState : IState
    {
        private const string CoreGameplaySceneName = "Core";
        private readonly StateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;

        public LoadGameState(StateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.LoadScene(CoreGameplaySceneName, OnLoaded);
        }

        private void OnLoaded()
        {
            _stateMachine.EnterState<ConstructGameState>();
        }

        public void Exit() { }
    }
}