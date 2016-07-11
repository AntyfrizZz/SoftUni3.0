using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Children
{
    public string name;
    public string birthday;

    public Children(string name, string birthday)
    {
        this.name = name;
        this.birthday = birthday;
    }

    public override string ToString()
    {
        return $"{this.name} {this.birthday}";
    }
}
public class Pokemon
{
    public string name;
    public string type;

    public Pokemon(string name, string type)
    {
        this.name = name;
        this.type = type;
    }

    public override string ToString()
    {
        return $"{this.name} {this.type}";
    }
}

public class Parent
{
    public string name;
    public string birthday;

    public Parent(string name, string birthday)
    {
        this.name = name;
        this.birthday = birthday;
    }

    public override string ToString()
    {
        return $"{this.name} {this.birthday}";
    }
}

public class Car
{
    public string model;
    public int speed;

    public Car(string model, int speed)
    {
        this.model = model;
        this.speed = speed;
    }

    public override string ToString()
    {
        return $"{this.model} {this.speed}";
    }
}

public class Company
{
    public string name;
    public string department;
    public double salary;

    public Company(string name, string department, double salary)
    {
        this.name = name;
        this.department = department;
        this.salary = salary;
    }

    public override string ToString()
    {
        return $"{this.name} {this.department} {this.salary:F2}";
    }
}

public class Person
{
    public string name;
    public Company company;
    public Car car;
    public List<Parent> parents;
    public List<Children> childrens;
    public List<Pokemon> pokemons;

    public Person(string name)
    {
        this.name = name;
    }
}

public class Startup
{
    static void Main()
    {
        var people = new List<Person>();

        var inputLine = Console.ReadLine();

        while (!inputLine.Equals("End"))
        {
            var personInfo = inputLine.Split();
            

            if (!people.Any(p => p.name.Equals(personInfo[0])))
            {
                var tempPerson = new Person(personInfo[0]);
                people.Add(tempPerson);

                tempPerson.pokemons = new List<Pokemon>();
                tempPerson.parents = new List<Parent>();
                tempPerson.childrens = new List<Children>();
            }

            var currentPerson = people
                .First(p => p.name.Equals(personInfo[0]));


            switch (personInfo[1])
            {
                case "company":
                    AddCompany(currentPerson, personInfo);
                    break;
                case "car":
                    AddCar(currentPerson, personInfo);
                    break;
                case "pokemon":
                    AddPokemon(currentPerson, personInfo);
                    break;
                case "parents":
                    AddParents(currentPerson, personInfo);
                    break;
                case "children":
                    AddChildren(currentPerson, personInfo);
                    break;
            }

            inputLine = Console.ReadLine();
        }

        var name = Console.ReadLine();

        var person = people
            .First(p => p.name.Equals(name));

        var resultForPrint = new StringBuilder();

        resultForPrint.AppendLine(person.name);
        resultForPrint.AppendLine("Company:");

        if (person.company != null)
        {
            resultForPrint.AppendLine(person.company.ToString());
        }

        resultForPrint.AppendLine("Car:");

        if (person.car != null)
        {
            resultForPrint.AppendLine(person.car.ToString());
        }

        resultForPrint.AppendLine("Pokemon:");

        if (person.pokemons.Count > 0)
        {
            foreach (var pokemon in person.pokemons)
            {
                resultForPrint.AppendLine(pokemon.ToString());
            }
        }

        resultForPrint.AppendLine("Parents:");

        if (person.parents.Count > 0)
        {
            foreach (var parent in person.parents)
            {
                resultForPrint.AppendLine(parent.ToString());
            }
        }

        resultForPrint.AppendLine("Children:");

        if (person.childrens.Count > 0)
        {
            foreach (var children in person.childrens)
            {
                resultForPrint.AppendLine(children.ToString());
            }
        }

        Console.Write(resultForPrint);

    }

    private static void AddChildren(Person currentPerson, string[] personInfo)
    {
        var tempChildren = new Children(personInfo[2], personInfo[3]);
        currentPerson.childrens.Add(tempChildren);
    }

    private static void AddParents(Person currentPerson, string[] personInfo)
    {
        var tempParent = new Parent(personInfo[2], personInfo[3]);
        currentPerson.parents.Add(tempParent);
    }

    private static void AddPokemon(Person currentPerson, string[] personInfo)
    {
        var tempPokemon = new Pokemon(personInfo[2], personInfo[3]);
        currentPerson.pokemons.Add(tempPokemon);
    }

    private static void AddCar(Person currentPerson, string[] personInfo)
    {
        var tempCar = new Car(personInfo[2], int.Parse(personInfo[3]));
        currentPerson.car = tempCar;
    }

    private static void AddCompany(Person currentPerson, string[] personInfo)
    {
        var tempCompany = new Company(personInfo[2], personInfo[3], double.Parse(personInfo[4]));
        currentPerson.company = tempCompany;
    }
}