namespace LambdaCore_Skeleton.Collection
{
    using System;
    using System.Collections.Generic;
    using Contracts.Models;

    public class LStack
    {
        private LinkedList<IFragment> innerList;

        public LStack()
        {
            this.innerList = new LinkedList<IFragment>();
        }

        public int Count()
        {
            return this.innerList.Count;
        }

        public void Push(IFragment item)
        {
            this.innerList.AddLast(item);
        }

        public IFragment Pop()
        {
            var popped = this.innerList.Last.Value;
            this.innerList.RemoveLast();
            return popped;
        }

        public IFragment Peek()
        {
            return this.innerList.Last.Value;
        }

        public bool IsEmpty()
        {
            return this.innerList.Count > 0;
        }
    }
}
