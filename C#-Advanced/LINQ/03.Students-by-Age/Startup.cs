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

        var secondGroupStudents = studentsList
            .Where(s => s.Age >= 18 && s.Age <= 24)
            .Select(s => $"{s.FirstName} {s.LastName} {s.Age}");

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
    public int Age { get; set; }

    public Student(string firstName, string lastName, int age)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
    }
}