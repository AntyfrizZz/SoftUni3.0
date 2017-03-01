namespace _07EqualityLogic
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var sortedPeople = new SortedSet<Person>();
            var hashPeople = new HashSet<Person>();

            var numberOflines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOflines; i++)
            {
                var personInfo = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var personName = personInfo[0];
                var personAge = int.Parse(personInfo[1]);

                var person = new Person(personName, personAge);

                sortedPeople.Add(person);
                hashPeople.Add(person);
            }

            Console.WriteLine(sortedPeople.Count);
            Console.WriteLine(hashPeople.Count);
        }
    }
}
