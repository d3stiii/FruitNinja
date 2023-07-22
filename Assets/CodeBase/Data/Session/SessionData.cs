namespace CodeBase.Data.Session
{
    public class SessionData
    {
        public readonly ScoreData ScoreData;
        public readonly AttemptsData AttemptsData;
        
        public SessionData()
        {
            ScoreData = new ScoreData();
            AttemptsData = new AttemptsData();
        }
    }
}