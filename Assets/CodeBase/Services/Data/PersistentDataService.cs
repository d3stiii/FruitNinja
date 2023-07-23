using CodeBase.Data.Persistent;

namespace CodeBase.Services.Data
{
    public interface IPersistentDataService
    {
        PersistentData PersistentData { get; set; }
    }

    public class PersistentDataService : IPersistentDataService
    {
        public PersistentData PersistentData { get; set; }
    }
}