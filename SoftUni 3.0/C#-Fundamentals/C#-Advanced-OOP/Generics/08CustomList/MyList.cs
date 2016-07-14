namespace _08CustomList
{
    using System;

    public class MyList<T> 
        where T : IComparable
    {
        public MyList(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public override string ToString()
        {
            return $"{this.Value.GetType().FullName}: {this.Value}";
        }
    }
}
