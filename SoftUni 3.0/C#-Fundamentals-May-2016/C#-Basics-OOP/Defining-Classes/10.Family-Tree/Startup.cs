using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class Person
{
    public string name;
    public string birthday;
    public List<Person> parents;
    public List<Person> children;

    public Person()
    {
        this.name = string.Empty;
        this.birthday = string.Empty;
        this.parents = new List<Person>();
        this.children = new List<Person>();
    }
    public override string ToString()
    {
        return $"{this.name} {this.birthday}";
    }
}
class Startup
{
    static void Main()
    {
        var people = new List<Person>();
        var storePeople = new List<string>();
        var person = Console.ReadLine();

        var inputLine = Console.ReadLine();

        while (!inputLine.Equals("End"))
        {
            var info = Regex.Split(inputLine, " - ");

            if (info.Length == 1)
            {
                var lastIndexOfSpace = inputLine.LastIndexOf(" ");

                var name = inputLine.Substring(0, lastIndexOfSpace);
                var birthday = inputLine.Substring(lastIndexOfSpace + 1);

                var newPerson = new Person();

                newPerson.name = name;
                newPerson.birthday = birthday;

                people.Add(newPerson);

            }
            else
            {
                storePeople.Add(inputLine);
            }

            inputLine = Console.ReadLine();
        }

        foreach (var storePerson in storePeople)
        {
            Person parent;
            Person children;

            var info = Regex.Split(storePerson, " - ");

            if (info[0].Contains('/') && info[1].Contains('/'))
            {
                var parentBirhtday = info[0];
                var childrenBirthday = info[1];

                parent = people
                        .First(p => p.birthday.Equals(parentBirhtday));
                children = people
                        .First(p => p.birthday.Equals(childrenBirthday));
            }
            else if (info[0].Contains('/') || info[1].Contains('/'))
            {
                var name = string.Empty;
                var birthday = string.Empty;

                if (info[0].Contains('/'))
                {
                    birthday = info[0];
                    name = info[1];

                    parent = people
                        .First(p => p.birthday.Equals(birthday));
                    children = people
                        .First(p => p.name.Equals(name));
                }
                else
                {
                    birthday = info[1];
                    name = info[0];

                    children = people
                        .First(p => p.birthday.Equals(birthday));
                    parent = people
                        .First(p => p.name.Equals(name));
                }
            }
            else
            {
                var parentName = info[0];
                var childrenName = info[1];

                parent = people
                        .First(p => p.name.Equals(parentName));
                children = people
                        .First(p => p.name.Equals(childrenName));
            }

            if (!parent.children.Contains(children))
            {
                parent.children.Add(children);
            }
            if (!children.parents.Contains(parent))
            {
                children.parents.Add(parent);
            }
        }

        var result = new StringBuilder();
        Person ourPerson;

        if (person.Contains('/'))
        {
            ourPerson = people.First(p => p.birthday.Equals(person));
        }
        else
        {
            ourPerson = people.First(p => p.name.Equals(person));
        }

        result.AppendLine(ourPerson.ToString());

        result.AppendLine("Parents:");
        foreach (var parent in ourPerson.parents)
        {
            result.AppendLine(parent.ToString());
        }

        result.AppendLine("Children:");
        foreach (var child in ourPerson.children)
        {
            result.AppendLine(child.ToString());
        }

        Console.Write(result);
    }
}