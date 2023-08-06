using CodeBase.Services.Bombs;
using CodeBase.Services.Fruits;

namespace CodeBase.States
{
    public class GameplayState : IState
    {
        private readonly StateMachine _stateMachine;
        private readonly IFruitSpawner _fruitSpawner;
        private readonly IBombSpawner _bombSpawner;
        private readonly IAttemptsObserver _attemptsObserver;

        public GameplayState(StateMachine stateMachine, IFruitSpawner fruitSpawner, IBombSpawner bombSpawner,
            IAttemptsObserver attemptsObserver)
        {
            _stateMachine = stateMachine;
            _fruitSpawner = fruitSpawner;
            _bombSpawner = bombSpawner;
            _attemptsObserver = attemptsObserver;
        }

        public void Enter()
        {
            _attemptsObserver.SubscribeUpdates();
            _attemptsObserver.Lost += OnLost;
            _bombSpawner.StartSpawning();
            _fruitSpawner.StartSpawning();
        }

        public void Exit()
        {
            _attemptsObserver.Lost -= OnLost;
            _attemptsObserver.Cleanup();
            _bombSpawner.StopSpawning();
            _fruitSpawner.StopSpawning();
        }

        private void OnLost() =>
            _stateMachine.EnterState<GameOverState>();
    }
}