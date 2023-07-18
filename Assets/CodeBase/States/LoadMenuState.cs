using CodeBase.Services;
using UnityEngine;

namespace CodeBase.States
{
    public class LoadMenuState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;

        public LoadMenuState(StateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.LoadScene("Menu", () => Debug.Log("Loaded Menu scene"));
        }

        public void Exit() { }
    }
}