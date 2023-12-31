﻿using CodeBase.Services.Bombs;
using CodeBase.Services.Data;
using CodeBase.Services.Fruits;
using CodeBase.Services.Skins;
using CodeBase.Services.UI;

namespace CodeBase.States
{
    public class ConstructGameState : IState
    {
        private readonly IUIFactory _uiFactory;
        private readonly IFruitFactory _fruitFactory;
        private readonly IFruitObserver _fruitObserver;
        private readonly ISessionDataService _sessionDataService;
        private readonly IBladeFactory _bladeFactory;
        private readonly IBombFactory _bombFactory;
        private readonly StateMachine _stateMachine;

        public ConstructGameState(StateMachine stateMachine, IUIFactory uiFactory, IFruitFactory fruitFactory,
            IFruitObserver fruitObserver, ISessionDataService sessionDataService, IBladeFactory bladeFactory,
            IBombFactory bombFactory)
        {
            _uiFactory = uiFactory;
            _fruitFactory = fruitFactory;
            _fruitObserver = fruitObserver;
            _sessionDataService = sessionDataService;
            _bladeFactory = bladeFactory;
            _bombFactory = bombFactory;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            Cleanup();
            InitUI();
            _bladeFactory.CreateBlade();

            _stateMachine.EnterState<GameplayState>();
        }

        private void InitUI() =>
            _uiFactory.GetOrCreateHud();

        private void Cleanup()
        {
            _fruitFactory.Cleanup();
            _fruitObserver.Cleanup();
            _sessionDataService.Reset();
            _bombFactory.Cleanup();
        }

        public void Exit() { }
    }
}