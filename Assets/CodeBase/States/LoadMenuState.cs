using CodeBase.Services;

namespace CodeBase.States
{
    public class LoadMenuState : IState
    {
        private const string MenuSceneName = "Menu";
        private readonly StateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;

        public LoadMenuState(StateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter() =>
            _sceneLoader.LoadScene(MenuSceneName, OnLoaded);

        public void Exit() { }

        private void OnLoaded() =>
            _stateMachine.EnterState<MainMenuState>();
    }
}