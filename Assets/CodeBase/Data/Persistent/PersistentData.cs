using System;

namespace CodeBase.Data.Persistent
{
    [Serializable]
    public class PersistentData
    {
        public HighScoreData HighScoreData;
        public CreditsData CreditsData;
        public PurchaseData PurchaseData;
        public SkinData SkinData;

        public PersistentData(string defaultSkin)
        {
            HighScoreData = new HighScoreData();
            CreditsData = new CreditsData();
            PurchaseData = new PurchaseData();
            SkinData = new SkinData(defaultSkin);
        }
    }
}