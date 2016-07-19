namespace Executor.Interfaces.DataStructures
{
    using System;
    using System.Collections.Generic;

    public interface ISimpleOrderedBag<T> : IEnumerable<T> where T : IComparable<T>
    {
        int Size { get; }

        void Add(T element);

        void AddAll(ICollection<T> elements);

        string JoinWith(string joiner);
    }
}
