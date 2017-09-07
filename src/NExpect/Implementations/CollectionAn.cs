﻿using System.Collections.Generic;
using NExpect.Interfaces;
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable MemberCanBePrivate.Global

namespace NExpect.Implementations
{
    internal class CollectionAn<T> :
        ExpectationContext<IEnumerable<T>>,
        ICollectionAn<T>
    {
        public IInstanceContinuation Instance => new InstanceContinuation<T>(Actual.GetType(), this as IExpectationContext<T>);

        public IEnumerable<T> Actual { get; }

        public CollectionAn(IEnumerable<T> actual)
        {
            Actual = actual;
        }
    }
}