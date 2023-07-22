using CodeBase.Data.Session;

namespace CodeBase.Services.Data
{
    public class SessionDataService : ISessionDataService
    {
        public SessionData SessionData { get; set; } = new();
    }

    public interface ISessionDataService
    {
        public SessionData SessionData { get; set; }
    }
}