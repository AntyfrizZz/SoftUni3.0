namespace _08CustomList
{
    using System;

    public class MyList<T>
        where T : IComparable<T>
    {
        private const int InitialCapacity = 16;

        public MyList()
        {
            this.Capacity = InitialCapacity;
            this.Collection = new T[this.Capacity];
            this.Count = 0;
        }

        public T[] Collection { get; set; }

        public int Count { get; private set; }

        public int Capacity { get; private set; }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.Collection[index];
            }
        }

        public void Add(T element)
        {
            if (this.Count == this.Collection.Length)
            {
                Resize();
            }

            this.Collection[this.Count] = element;
            Count++;
        }

        private void Resize()
        {
            int currentLentgth = this.Collection.Length;
            T[] newCollection = new T[currentLentgth * 2];
            Array.Copy(this.Collection, newCollection, currentLentgth);
            this.Collection = newCollection;
        }

        public T Remove(int index)
        {
            this.ValidateOperation();

            this.ValidateIndex(index);

            T element = this.Collection[index];

            this.DecreaseElementsCount(index);

            return element;
        }

        private void DecreaseElementsCount(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                this.Collection[i] = this.Collection[i + 1];
            }

            this.Collection[this.Count - 1] = default(T);
            this.Count--;
        }

        public bool Contains(T element)
        {
            if (this.Count == 0)
            {
                return false;
            }

            for (int i = 0; i < this.Count; i++)
            {
                if (this.Collection[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            this.ValidateOperation();
            this.ValidateIndex(firstIndex, secondIndex);

            var temp = this.Collection[firstIndex];
            this.Collection[firstIndex] = this.Collection[secondIndex];
            this.Collection[secondIndex] = temp;
        }

        public int CountGreaterThan(T element)
        {
            this.ValidateOperation();

            var counter = 0;

            for (int i = 0; i < this.Count; i++)
            {
                if (this.Collection[i].CompareTo(element) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }

        public T Max()
        {
            T maxValue = this.Collection[0];

            for (int i = 0; i < this.Count; i++)
            {
                if (this.Collection[i].CompareTo(maxValue) > 0)
                {
                    maxValue = this.Collection[i];
                }
            }

            return maxValue;
        }

        public T Min()
        {
            T minValue = this.Collection[0];

            for (int i = 0; i < this.Count; i++)
            {
                if (this.Collection[i].CompareTo(minValue) < 0)
                {
                    minValue = this.Collection[i];
                }
            }

            return minValue;
        }

        public void Print()
        {
            for (int i = 0; i < this.Count; i++)
            {
                Console.WriteLine(this.Collection[i].ToString());
            }
        }

        private void ValidateOperation()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Collection is empty bla bla bla");
            }
        }

        private void ValidateIndex(params int[] indices)
        {
            foreach (int index in indices)
            {
                if (index >= this.Count || index < 0)
                {
                    throw new IndexOutOfRangeException("Index is outside of bla bla bla");
                }
            }
        }

        public override string ToString()
        {
            return $"{this.Collection.GetType().FullName}: {this.Collection}";
        }
    }
}
