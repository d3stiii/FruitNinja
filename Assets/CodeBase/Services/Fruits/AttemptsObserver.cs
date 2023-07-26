using System;
using CodeBase.Services.Data;

namespace CodeBase.Services.Fruits
{
    public interface IAttemptsObserver
    {
        event Action Lost;
        void SubscribeUpdates();
        void Cleanup();
    }

    public class AttemptsObserver : IAttemptsObserver
    {
        public event Action Lost;

        private readonly ISessionDataService _sessionDataService;

        public AttemptsObserver(ISessionDataService sessionDataService) =>
            _sessionDataService = sessionDataService;

        public void SubscribeUpdates() =>
            _sessionDataService.SessionData.AttemptsData.Changed += CheckLose;

        private void CheckLose()
        {
            if (_sessionDataService.SessionData.AttemptsData.Value <= 0)
            {
                Lost?.Invoke();
            }
        }

        public void Cleanup() =>
            _sessionDataService.SessionData.AttemptsData.Changed -= CheckLose;
    }
}