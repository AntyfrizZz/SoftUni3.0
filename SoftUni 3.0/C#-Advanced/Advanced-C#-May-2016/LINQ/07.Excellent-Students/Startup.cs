using System;
using System.Collections.Generic;
using System.Linq;

class Startup
{
    static void Main()
    {
        var studentsList = new List<Student>();

        var inputLine = Console.ReadLine();

        while (inputLine != "END")
        {
            var firstName = inputLine
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];
            var lastName = inputLine
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
            var grades = inputLine
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(2)
                .Select(int.Parse)
                .ToList();

            studentsList.Add(new Student(firstName, lastName, grades));

            inputLine = Console.ReadLine();
        }

        studentsList
            .Where(s => s.Grades.Contains(6))
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
    public List<int> Grades { get; set; }

    public Student(string firstName, string lastName, List<int> grades)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Grades = grades;
    }
}