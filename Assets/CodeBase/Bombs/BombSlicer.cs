using CodeBase.Logic;
using CodeBase.States;
using UnityEngine;
using Zenject;

namespace CodeBase.Bombs
{
    public class BombSlicer : MonoBehaviour, ISlicable
    {
        private bool _sliced;
        private StateMachine _stateMachine;

        [Inject]
        public void Construct(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Slice(Vector3 direction, Vector3 position, float sliceForce)
        {
            if (_sliced)
                return;
            
            _stateMachine.EnterState<GameOverState>();
        }
    }
}