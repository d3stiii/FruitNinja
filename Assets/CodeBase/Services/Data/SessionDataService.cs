using CodeBase.Data.Session;

namespace CodeBase.Services.Data
{
    public interface ISessionDataService
    {
        public SessionData SessionData { get; set; }
        public void Reset();
    }

    public class SessionDataService : ISessionDataService
    {
        public SessionData SessionData { get; set; } = new();

        public void Reset()
        {
            SessionData.AttemptsData.Reset();
            SessionData.ScoreData.Reset();
        }
    }
}