using System;

namespace CodeBase.Data.Persistent
{
    [Serializable]
    public class HighScoreData
    {
        public event Action Changed;
        public int HighScore;

        public void ChangeScore(int value)
        {
            HighScore = value;
            Changed?.Invoke();
        }
    }
}