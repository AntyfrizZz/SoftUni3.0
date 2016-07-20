namespace _01ListyIterator
{
    using System;
    using System.Collections.Generic;

    public class ListyIterator<T>
    {
        private readonly List<T> listyCollection;

        public ListyIterator(List<T> collection)
        {
            this.listyCollection = collection;
        }

        public int Index { get; private set; }

        public bool Move()
        {
            if (this.Index == this.listyCollection.Count - 1)
            {
                return false;
            }

            this.Index++;
            return true;
        }

        public bool HasNext()
        {
            if (this.Index == this.listyCollection.Count - 1)
            {
                return false;
            }

            return true;
        }

        public string Print()
        {
            if (this.listyCollection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            return this.listyCollection[this.Index].ToString();
        }
    }
}
