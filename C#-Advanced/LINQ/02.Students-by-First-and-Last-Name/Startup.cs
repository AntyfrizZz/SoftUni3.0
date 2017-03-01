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
            studentsList.Add(new Student(inputLine[0], inputLine[1]));

            inputLine = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        var secondGroupStudents = studentsList
            .Where(s => string.Compare(s.FirstName, s.LastName) < 0)
            .Select(s => $"{s.FirstName} {s.LastName}");

        foreach (var student in secondGroupStudents)
        {
            Console.WriteLine(student);
        }
    }
}

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Student(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }
}