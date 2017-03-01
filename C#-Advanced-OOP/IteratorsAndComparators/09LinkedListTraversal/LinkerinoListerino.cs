namespace _09LinkedListTraversal
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkerinoListerino<T> : IEnumerable<T> where T : IComparable<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void Add(T element)
        {
            if (this.Count == 0)
            {
                this.head = new Node<T>(element);

                this.Count++;
            }
            else if (this.Count == 1)
            {
                this.tail = new Node<T>(element);
                this.head.Next = this.tail;
                this.tail.Previous = this.head;

                this.Count++;
            }
            else
            {
                var newNode = new Node<T>(element);
                this.tail.Next = newNode;
                newNode.Previous = this.tail;
                this.tail = newNode;

                this.Count++;
            }
        }

        public bool Remove(T element)
        {
            if (this.Count == 0)
            {
                return false;
            }

            var counter = 1;
            var node = new Node<T>(element);
            var currentNode = this.head;

            while (counter <= this.Count)
            {
                if (node.Value.CompareTo(currentNode.Value) == 0)
                {
                    if (counter == 1)
                    {
                        this.head.Next.Previous = null;
                        this.head = this.head.Next;
                    }
                    else if (counter == this.Count)
                    {
                        this.tail.Previous.Next = null;
                        this.tail = this.tail.Previous;
                    }
                    else
                    {
                        currentNode.Previous.Next = currentNode.Next;
                        currentNode.Next.Previous = currentNode.Previous;
                    }

                    this.Count--;
                    return true;
                }

                currentNode = currentNode.Next;
                counter++;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.Count != 0)
            {
                var currentNode = this.head;
                var counter = 1;

                while (counter <= this.Count)
                {
                    yield return currentNode.Value;

                    counter++;
                    currentNode = currentNode.Next;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
