using System.Collections.Generic;
using _09.Collection_Hierarchy.Interfaces;namespace _09.Collection_Hierarchy.Models
{
    public class AddRemoveCollection : IAddable, IRemovable, ICollection
    {
        public AddRemoveCollection()
        {
           this. Collection = new List<string>();
        }

        public List<string> Collection { get; }

        public int Add(string element)
        {
            this.Collection.Insert(0, element);
            return 0;
        }

        public string Remove()
        {
            var removed = this.Collection[this.Collection.Count - 1];

            this.Collection.RemoveAt(this.Collection.Count - 1);

            return removed;
        }
    }
}
