using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

class Startup
{
    static void Main()
    {
        var inputLine = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var persons = new List<Person>();

        while (inputLine[0] != "END")
        {
            persons.Add(new Person($"{inputLine[0]} {inputLine[1]}", int.Parse(inputLine[2])));


            inputLine = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        var sortedPersons = persons
            .OrderBy(gr => gr.Group)
            .GroupBy(gr => gr.Group);
            

        foreach (var personGroup in sortedPersons)
        {
            var tempList = new List<Person>();
            Console.Write($"{personGroup.Key} - ");

            foreach (var person in personGroup)
            {
                tempList.Add(person);
            }

            Console.WriteLine(string.Join(", ", tempList));
        }
    }
}

public class Person
{
    public string Name { get; set; }
    public int Group { get; set; }

    public Person(string name, int group)
    {
        this.Name = name;
        this.Group = group;
    }

    public override string ToString()
    {
        return $"{Name}";
    }
}