namespace _05ComparingObjects
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (!input[0].Equals("END"))
            {
                var personName = input[0];
                var personAge = int.Parse(input[1]);
                var personTown = input[2];
                 
                var person = new Person(personName, personAge, personTown);

                input = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(Person.FindDuplicate(int.Parse(Console.ReadLine())));
        }
    }
}
