using System;
using System.Collections.Generic;
using System.Linq;

class Startup
{
    static void Main()
    {
        var specialties = new List<StudentSpecialty>();
        var students = new List<Student>();

        var inputLine = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        while (inputLine[0] != "Students:")
        {
            specialties.Add(new StudentSpecialty($"{inputLine[0]} {inputLine[1]}", int.Parse(inputLine[2])));

            inputLine = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        inputLine = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        while (inputLine[0] != "END")
        {
            students.Add(new Student($"{inputLine[1]} {inputLine[2]}", int.Parse(inputLine[0])));

            inputLine = Console.ReadLine()
            .Split(new[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        }

        var joined = from sp in specialties
            join st in students
                on sp.FacultyNumber equals st.FacultyNumber
            select new {st.StudentName, st.FacultyNumber, sp.SpecialtyName};

        joined
            .OrderBy(s => s.StudentName)
            .ToList()
            .ForEach(s => Console.WriteLine($"{s.StudentName} {s.FacultyNumber} {s.SpecialtyName}"));
    }
}

class StudentSpecialty
{
    public string SpecialtyName { get; set; }
    public int FacultyNumber { get; set; }

    public StudentSpecialty(string specialtyName, int facultyNumber)
    {
        this.SpecialtyName = specialtyName;
        this.FacultyNumber = facultyNumber;
    }
}

class Student
{
    public string StudentName { get; set; }
    public int FacultyNumber { get; set; }

    public Student(string studentName, int facultyNumber)
    {
        this.StudentName = studentName;
        this.FacultyNumber = facultyNumber;
    }
}