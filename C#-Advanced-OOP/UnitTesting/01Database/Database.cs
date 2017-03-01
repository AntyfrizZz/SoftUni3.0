namespace _01Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Database
    {
        private const int DefaultCapacity = 16;
        private int[] elements;

        public Database(IEnumerable<int> elements)
        {
            this.Elements = elements.ToArray();
        }

        public int[] Elements
        {
            get
            {
                List<int> numbers = new List<int>();
                for (int i = 0; i < this.Count; i++)
                {
                    numbers.Add(this.elements[i]);
                }

                return numbers.ToArray();
            }
            private set
            {
                if (value.Length > 16 || value.Length < 1)
                {
                    throw new InvalidOperationException();
                }

                this.elements = new int[DefaultCapacity];
                int bufferIndex = 0;

                foreach (int element in value)
                {
                    this.elements[bufferIndex++] = element;
                }

                this.Count = value.Length;
            }
        }

        public int Capacity => DefaultCapacity;

        public int Count { get; private set; }

        public void Add(int element)
        {
            if (this.Count == DefaultCapacity)
            {
                throw new InvalidOperationException("Cannot add more elements in the collection");
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public void Remove()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot remove element from empty database!");
            }

            this.elements[this.Count] = default(int);
            this.Count--;
        }
    }
}
