using CodeBase.Services.SaveLoad;
using UnityEngine.Device;

namespace CodeBase.States
{
    public class ExitGameState : IState
    {
        private readonly ISaveLoadService _saveLoadService;

        public ExitGameState(ISaveLoadService saveLoadService) =>
            _saveLoadService = saveLoadService;

        public void Enter()
        {
            _saveLoadService.Save();
            Application.Quit();
        }

        public void Exit() { }
    }
}