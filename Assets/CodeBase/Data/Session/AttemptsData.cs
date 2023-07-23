using System;

namespace CodeBase.Data.Session
{
    public class AttemptsData
    {
        public event Action Changed;
        public int AttemptsCount { get; private set; }

        public AttemptsData()
        {
            Reset();
        }

        public void SpendAttempts(int count = 1)
        {
            if (AttemptsCount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Attempts count should be more than zero!");
            }

            AttemptsCount -= count;
            Changed?.Invoke();
        }

        public void Reset()
        {
            AttemptsCount = 3;
        }
    }
}