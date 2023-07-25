using CodeBase.Services.UI;
using CodeBase.UI.Screens;

namespace CodeBase.States
{
    public class BladeShopState : IState
    {
        private readonly IScreenService _screenService;

        public BladeShopState(IScreenService screenService)
        {
            _screenService = screenService;
        }

        public void Enter()
        {
            _screenService.Show<BladeShopScreen>();
        }

        public void Exit() { }
    }
}