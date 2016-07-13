namespace _09.Collection_Hierarchy.Models
{
    using System.Collections.Generic;

    using Interfaces;

    public class AddCollection : IAddable, ICollection
    {
        public AddCollection()
        {
            this.Collection = new List<string>();
        }

        public List<string> Collection { get; }

        public int Add(string element)
        {
            this.Collection.Add(element);
            return this.Collection.Count - 1;
        }
    }
}
