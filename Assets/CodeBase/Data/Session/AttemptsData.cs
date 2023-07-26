using System;

namespace CodeBase.Data.Session
{
    public class AttemptsData
    {
        public event Action Changed;
        public int Value { get; private set; }

        public AttemptsData()
        {
            Reset();
        }

        public void SpendAttempts(int count = 1)
        {
            if (Value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Attempts count should be more than zero!");
            }

            Value -= count;
            Changed?.Invoke();
        }

        public void Reset()
        {
            Value = 3;
        }
    }
}