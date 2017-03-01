namespace _03Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stacky<T> : IEnumerable<T>
    {
        private readonly List<T> stacky;

        public Stacky()
        {
            this.stacky = new List<T>();
        }

        public void Push(List<T> elements)
        {
            foreach (var element in elements)
            {
                this.stacky.Add(element);
            }
        }

        public void Pop()
        {
            if (this.stacky.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            this.stacky.RemoveAt(this.stacky.Count - 1);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.stacky.Count - 1; i >= 0; i--)
            {
                yield return this.stacky[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
