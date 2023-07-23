using System;

namespace CodeBase.Data.Persistent
{
    [Serializable]
    public class PersistentData
    {
        public HighScoreData HighScoreData;
        public CreditsData CreditsData;

        public PersistentData()
        {
            HighScoreData = new HighScoreData();
            CreditsData = new CreditsData();
        }
    }
}