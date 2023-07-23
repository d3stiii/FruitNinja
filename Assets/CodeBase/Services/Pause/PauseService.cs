using System.Collections.Generic;

namespace CodeBase.Services.Pause
{
    public interface IPauseService
    {
        bool IsPaused { get; }
        void Register(IPauseHandler handler);
        void Unregister(IPauseHandler handler);
        void Pause();
        void Unpause();
    }

    public class PauseService : IPauseService
    {
        private readonly List<IPauseHandler> _handlers = new();

        public bool IsPaused { get; private set; }

        public void Register(IPauseHandler handler) =>
            _handlers.Add(handler);

        public void Unregister(IPauseHandler handler) =>
            _handlers.Remove(handler);

        public void Pause()
        {
            IsPaused = true;

            foreach (var handler in _handlers)
            {
                handler.Pause();
            }
        }

        public void Unpause()
        {
            IsPaused = false;

            foreach (var handler in _handlers)
            {
                handler.Unpause();
            }
        }
    }
}