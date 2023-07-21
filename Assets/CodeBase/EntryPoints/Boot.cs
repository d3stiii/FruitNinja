using CodeBase.States;
using UnityEngine;
using Zenject;

namespace CodeBase.EntryPoints
{
    public class Boot : MonoBehaviour
    {
        private StateMachine _stateMachine;

        public void Start() => 
            _stateMachine.EnterState<LoadMenuState>();

        [Inject]
        public void Construct(StateMachine stateMachine) => 
            _stateMachine = stateMachine;
    }
}