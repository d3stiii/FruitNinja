using System;

namespace CodeBase.Data.Session
{
    public class AttemptsData
    {
        public event Action Changed;
        public int AttemptsCount;

        public AttemptsData()
        {
            Reset();
        }

        public void SpendAttempts(int count = 1)
        {
            if (AttemptsCount <= 0)
            {
                return;
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