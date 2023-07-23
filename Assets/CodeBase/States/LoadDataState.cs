using CodeBase.Services.SaveLoad;

namespace CodeBase.States
{
    public class LoadDataState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly ISaveLoadService _saveLoadService;

        public LoadDataState(StateMachine stateMachine, ISaveLoadService saveLoadService)
        {
            _stateMachine = stateMachine;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            _saveLoadService.Load();
            _stateMachine.EnterState<LoadMenuState>();
        }

        public void Exit() { }
    }
}