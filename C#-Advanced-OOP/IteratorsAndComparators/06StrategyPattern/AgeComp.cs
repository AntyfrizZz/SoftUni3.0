namespace _06StrategyPattern
{
    using System.Collections.Generic;

    class AgeComp : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
}
