using System;

namespace CodeBase.Data.Session
{
    public class ScoreData
    {
        public event Action Changed;
        public int Score;

        public void AddScore(int value)
        {
            Score += value;
            Changed?.Invoke();
        }

        public void Reset()
        {
            Score = 0;
        }
    }
}