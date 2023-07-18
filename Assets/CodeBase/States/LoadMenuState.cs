using CodeBase.Services;
using CodeBase.Services.UI;

namespace CodeBase.States
{
    public class LoadMenuState : IState
    {
        private const string MenuSceneName = "Menu";
        private readonly StateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IScreenFactory _screenFactory;

        public LoadMenuState(StateMachine stateMachine, ISceneLoader sceneLoader, IScreenFactory screenFactory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _screenFactory = screenFactory;
        }

        public void Enter()
        {
            _sceneLoader.LoadScene(MenuSceneName, OnLoaded);
        }

        public void Exit() { }

        private void OnLoaded()
        {
            _screenFactory.CreateUIRoot();
            _stateMachine.EnterState<MainMenuState>();
        }
    }
}