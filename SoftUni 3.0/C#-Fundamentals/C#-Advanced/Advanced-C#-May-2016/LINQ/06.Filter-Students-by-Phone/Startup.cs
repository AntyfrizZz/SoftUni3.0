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
            studentsList.Add(new Student(inputLine[0], inputLine[1], inputLine[2]));

            inputLine = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        studentsList
            .Where(s => s.Phone.IndexOf("02") == 0 || s.Phone.IndexOf("+3592") == 0)
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
    public string Phone { get; set; }

    public Student(string firstName, string lastName, string phone)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Phone = phone;
    }
}