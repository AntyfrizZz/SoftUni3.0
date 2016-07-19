using System;
using System.Collections.Generic;

public class Student
{
    public static HashSet<string> uniqueStudents;
    public string name;

    public Student(string name)
    {
        this.name = name;
    }

    static Student()
    {
        uniqueStudents = new HashSet<string>();
    }
}

class Startup
{
    static void Main()
    {
        var name = Console.ReadLine();

        while (!name.Equals("End"))
        {
            var student = new Student(name);

            Student.uniqueStudents.Add(student.name);

            name = Console.ReadLine();
        }

        
        Console.WriteLine(Student.uniqueStudents.Count);
    }
}