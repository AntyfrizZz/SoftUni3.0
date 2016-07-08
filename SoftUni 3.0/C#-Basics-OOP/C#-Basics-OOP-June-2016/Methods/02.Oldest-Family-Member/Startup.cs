using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Person
{
    public string name;
    public int age;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
}

public class Family
{
    public List<Person> family;

    public void AddMember(Person member)
    {
        family.Add(member);
    }

    public Person GetOldestMember()
    {
        return family
            .OrderByDescending(p => p.age)
            .First();
    }
}

class Startup
{
    static void Main()
    {
        MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
        if (oldestMemberMethod == null || addMemberMethod == null)
        {
            throw new Exception();
        }

        var family = new Family();
        family.family = new List<Person>();

        var numberOfPeople = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfPeople; i++)
        {
            var personInfo = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var name = personInfo[0];
            var age = int.Parse(personInfo[1]);

            var person = new Person(name, age);

            family.family.Add(person);
        }

        var oldestMember = family.GetOldestMember();
        Console.WriteLine($"{oldestMember.name} {oldestMember.age}");
    }
}