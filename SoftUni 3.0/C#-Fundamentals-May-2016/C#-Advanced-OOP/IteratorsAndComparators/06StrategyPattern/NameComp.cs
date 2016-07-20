namespace _06StrategyPattern
{
    using System;
    using System.Collections.Generic;

    public class NameComp : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            int result = x.Name.Length.CompareTo(y.Name.Length);

            if (result == 0)
            {
                var firstName = x.Name[0].ToString();
                var secondName = y.Name[0].ToString();

                result = string.Compare(firstName, secondName, StringComparison.OrdinalIgnoreCase);
            }

            return result;
        }
    }
}
