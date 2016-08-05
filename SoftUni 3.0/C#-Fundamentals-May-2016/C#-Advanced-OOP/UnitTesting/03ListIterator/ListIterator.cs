namespace _03ListIterator
{
    using System;
    using System.Collections.Generic;

    public class ListIterator
    {
        private int currentIndex = 0;

        public ListIterator(List<string> collection)
        {
            this.Collection = collection;
        }

        public List<string> Collection { get; }

        public bool Move()
        {
            if (this.currentIndex + 1 >= this.Collection.Count)
            {
                return false;
            }

            this.currentIndex++;
            return true;
        }

        public bool HasNext()
        {
            return this.currentIndex + 1 < this.Collection.Count;
        }

        public void Print()
        {
            if (this.Collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.Collection[this.currentIndex]);
        }
    }
}
