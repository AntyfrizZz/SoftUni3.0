using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Startup
{
    static void Main()
    {
        var people = new List<Person>();
        var result = new StringBuilder();

        var lines = int.Parse(Console.ReadLine());

        for (int i = 0; i < lines; i++)
        {
            var personArgs = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var name = personArgs[0];
            var age = int.Parse(personArgs[1]);

            var person = new Person(name, age);

            people.Add(person);
        }

        var sortedPeople = people
            .OrderBy(n => n.Name)
            .Where(a => a.Age > 30);

        foreach (var person in sortedPeople)
        {
            result.AppendLine($"{person.Name} - {person.Age}");
        }

        Console.Write(result);
    }
}