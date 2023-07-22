using CodeBase.Services.Fruits;
using CodeBase.Services.UI;
using CodeBase.UI;

namespace CodeBase.States
{
    public class GameOverState : IState
    {
        private readonly IScreenService _screenService;
        private readonly IFruitFactory _fruitFactory;

        public GameOverState(IScreenService screenService, IFruitFactory fruitFactory)
        {
            _screenService = screenService;
            _fruitFactory = fruitFactory;
        }

        public void Enter()
        {
            _fruitFactory.Cleanup();
            _screenService.Show<GameOverScreen>();
        }

        public void Exit() { }
    }
}