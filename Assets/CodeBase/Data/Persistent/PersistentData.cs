using System;

namespace CodeBase.Data.Persistent
{
    [Serializable]
    public class PersistentData
    {
        public HighScoreData HighScoreData;
        public CreditsData CreditsData;
        public PurchaseData PurchaseData;
        public SkinsData SkinsData;

        public PersistentData(string defaultSkin)
        {
            HighScoreData = new HighScoreData();
            CreditsData = new CreditsData();
            PurchaseData = new PurchaseData();
            SkinsData = new SkinsData(defaultSkin);
        }
    }
}