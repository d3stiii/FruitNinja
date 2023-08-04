using CodeBase.Services.UI;
using CodeBase.UI.Screens;

namespace CodeBase.States
{
    public class SkinInventoryState : IState
    {
        private readonly IScreenService _screenService;

        public SkinInventoryState(IScreenService screenService)
        {
            _screenService = screenService;
        }

        public void Enter()
        {
            _screenService.Show<SkinInventoryScreen>();
        }

        public void Exit() { }
    }
}