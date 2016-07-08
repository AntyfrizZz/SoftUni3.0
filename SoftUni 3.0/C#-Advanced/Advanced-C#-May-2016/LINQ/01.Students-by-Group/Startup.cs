using System;
using System.Collections.Generic;
using System.Linq;

class Startup
{
    static void Main()
    {
        var studentsList = new List<Student>();

        var inputLine = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        while (inputLine[0] != "END")
        {
            studentsList.Add(new Student(inputLine[0], inputLine[1], int.Parse(inputLine[2])));

            inputLine = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        studentsList
            .Where(s => s.Group == 2)
            .OrderBy(s => s.FirstName)
            .Select(s => $"{s.FirstName} {s.LastName}")
            .ToList()
            .ForEach(s =>
            Console.WriteLine(s)
            );


    }
}

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Group { get; set; }

    public Student(string firstName, string lastName, int group)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Group = group;
    }
}