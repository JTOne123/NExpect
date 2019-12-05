﻿using NExpect.Interfaces;

namespace NExpect.Implementations.Fluency
{
    internal class For<T>:
        ExpectationContext<T>,
        IFor<T>
    {
        public T Actual { get; }
        public For(T actual)
        {
            Actual = actual;
        }
    }
}