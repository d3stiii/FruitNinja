using CodeBase.Services.Fruits;

namespace CodeBase.States
{
    public class GameplayState : IState
    {
        private readonly IFruitSpawner _fruitSpawner;

        public GameplayState(IFruitSpawner fruitSpawner) => 
            _fruitSpawner = fruitSpawner;

        public void Enter() => 
            _fruitSpawner.StartSpawning();

        public void Exit() => 
            _fruitSpawner.StopSpawning();
    }
}