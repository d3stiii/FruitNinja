using System;

namespace CodeBase.Data.Persistent
{
    [Serializable]
    public class CreditsData
    {
        public event Action Changed;
        public int Credits;

        public void AddCredits(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount),
                    "Credits amount should be more than zero!");
            }

            Credits += amount;
            Changed?.Invoke();
        }
    }
}