using System.Collections.Generic;

namespace _09.Collection_Hierarchy.Models
{
    using Interfaces;

    class MyList : IAddable, IRemovable, IUsed, ICollection
    {
        public MyList()
        {
            this.Collection = new List<string>();
        }

        public List<string> Collection { get; }

        public int Add(string element)
        {
            this.Collection.Insert(0, element);
            return 0;
        }

        public string Remove()
        {
            var removed = this.Collection[0];

            this.Collection.RemoveAt(0);

            return removed;
        }

        public int Used()
        {
            return this.Collection.Count;
        }
    }
}
