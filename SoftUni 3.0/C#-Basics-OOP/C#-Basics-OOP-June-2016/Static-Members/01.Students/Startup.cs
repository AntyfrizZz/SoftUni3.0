using System;

public class Student
{
    public static int numberOfStudents;
    public string name;

    public Student(string name)
    {
        this.name = name;
        numberOfStudents++;
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

            name = Console.ReadLine();
        }

        Console.WriteLine(Student.numberOfStudents);
    }
}