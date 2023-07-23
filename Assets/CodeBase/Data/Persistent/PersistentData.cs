using System;

namespace CodeBase.Data.Persistent
{
    [Serializable]
    public class PersistentData
    {
        public HighScoreData HighScoreData;

        public PersistentData()
        {
            HighScoreData = new HighScoreData();
        }
    }
}