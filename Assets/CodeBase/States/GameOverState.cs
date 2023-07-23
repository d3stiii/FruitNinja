﻿using CodeBase.Services.Pause;
using CodeBase.Services.UI;
using CodeBase.UI;

namespace CodeBase.States
{
    public class GameOverState : IState
    {
        private readonly IScreenService _screenService;
        private readonly IPauseService _pauseService;

        public GameOverState(IScreenService screenService, IPauseService pauseService)
        {
            _screenService = screenService;
            _pauseService = pauseService;
        }

        public void Enter()
        {
            _pauseService.Pause();
            _screenService.Show<GameOverScreen>();
        }

        public void Exit() =>
            _pauseService.Unpause();
    }
}