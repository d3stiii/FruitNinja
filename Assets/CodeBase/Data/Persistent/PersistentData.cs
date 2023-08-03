using System;

namespace CodeBase.Data.Persistent
{
    [Serializable]
    public class PersistentData
    {
        public HighScoreData HighScoreData;
        public CreditsData CreditsData;
        public PurchaseData PurchaseData;

        public PersistentData()
        {
            HighScoreData = new HighScoreData();
            CreditsData = new CreditsData();
            PurchaseData = new PurchaseData();
        }
    }
}