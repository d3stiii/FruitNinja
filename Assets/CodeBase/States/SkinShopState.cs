using CodeBase.Services.UI;
using CodeBase.UI.Screens;

namespace CodeBase.States
{
    public class SkinShopState : IState
    {
        private readonly IScreenService _screenService;

        public SkinShopState(IScreenService screenService)
        {
            _screenService = screenService;
        }

        public void Enter()
        {
            _screenService.Show<SkinShopScreen>();
        }

        public void Exit() { }
    }
}