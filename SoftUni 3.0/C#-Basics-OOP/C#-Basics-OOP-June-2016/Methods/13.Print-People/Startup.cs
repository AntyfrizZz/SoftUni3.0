using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    public string name;
    public int age;
    public string occupation;

    public Person(string name, int age, string occupation)
    {
        this.name = name;
        this.age = age;
        this.occupation = occupation;
    }

    public override string ToString()
    {
        return $"{this.name} - age: {this.age}, occupation: {this.occupation}";
    }
}
class Startup
{
    static void Main()
    {
        var people = new List<Person>();

        var personInfo = Console.ReadLine();

        while (!personInfo.Equals("END"))
        {
            var personArgs = personInfo.Split();
            people.Add(new Person(personArgs[0], int.Parse(personArgs[1]), personArgs[2]));

            personInfo = Console.ReadLine();
        }

        people
            .OrderBy(p => p.age)
            .ToList()
            .ForEach(p => Console.WriteLine(p));
    }
}