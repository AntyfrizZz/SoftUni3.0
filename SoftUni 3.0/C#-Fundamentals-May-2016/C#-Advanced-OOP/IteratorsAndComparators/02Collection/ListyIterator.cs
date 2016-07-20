namespace _02Collection
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ListyIterator<T> : IEnumerable<T>
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


        public string PrintAll()
        {
            if (this.listyCollection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            return string.Join(" ", this.listyCollection);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.listyCollection.Count; i++)
            {
                yield return this.listyCollection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
