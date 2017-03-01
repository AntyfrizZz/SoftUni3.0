namespace _06StrategyPattern
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var nameSortedSet = new SortedSet<Person>(new NameComp());
            var ageSortedSet = new SortedSet<Person>(new AgeComp());

            var numberOflines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOflines; i++)
            {
                var personInfo = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var personName = personInfo[0];
                var personAge = int.Parse(personInfo[1]);

                var person = new Person(personName, personAge);

                nameSortedSet.Add(person);
                ageSortedSet.Add(person);
            }

            foreach (var person in nameSortedSet)
            {
                Console.WriteLine(person);
            }


            foreach (var person in ageSortedSet)
            {
                Console.WriteLine(person);
            }
        }
    }
}
