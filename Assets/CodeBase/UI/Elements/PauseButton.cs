using CodeBase.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.Elements
{
    public class PauseButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        private StateMachine _stateMachine;

        private void Awake() =>
            _button.onClick.AddListener(() => _stateMachine.EnterState<PauseState>());

        [Inject]
        public void Construct(StateMachine stateMachine) =>
            _stateMachine = stateMachine;
    }
}