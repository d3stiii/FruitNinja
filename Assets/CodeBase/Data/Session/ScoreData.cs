﻿using System;

namespace CodeBase.Data.Session
{
    public class ScoreData
    {
        public event Action Changed;
        public int Value { get; private set; }

        public void AddScore(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Score amount should be more than zero!");
            }

            Value += value;
            Changed?.Invoke();
        }

        public void Reset()
        {
            Value = 0;
        }
    }
}