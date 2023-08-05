using System;

namespace CodeBase.Data.Persistent
{
    [Serializable]
    public class HighScoreData
    {
        public event Action Changed;
        public int Value;

        public void ChangeScore(int value)
        {
            if (value <= Value)
                return;

            Value = value;
            Changed?.Invoke();
        }
    }
}