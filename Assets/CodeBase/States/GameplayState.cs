using CodeBase.Services.Fruits;

namespace CodeBase.States
{
    public class GameplayState : IState
    {
        private readonly IFruitSpawner _fruitSpawner;
        private readonly IFruitObserver _fruitObserver;

        public GameplayState(IFruitSpawner fruitSpawner, IFruitObserver fruitObserver)
        {
            _fruitSpawner = fruitSpawner;
            _fruitObserver = fruitObserver;
        }

        public void Enter() =>
            _fruitSpawner.StartSpawning();

        public void Exit()
        {
            _fruitSpawner.StopSpawning();
            _fruitObserver.Cleanup();
        }
    }
} 