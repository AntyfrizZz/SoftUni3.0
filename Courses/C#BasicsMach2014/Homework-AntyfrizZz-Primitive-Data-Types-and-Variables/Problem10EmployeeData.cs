using System;
//A marketing company wants to keep record of its employees. Each record would have the following characteristics:
//•	First name
//•	Last name
//•	Age (0...100)
//•	Gender (m or f)
//•	Personal ID number (e.g. 8306112507)
//•	Unique employee number (27560000…27569999)
//Declare the variables needed to keep the information for a single employee using appropriate primitive data types. Use descriptive names. Print the data at the console.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/2.%20Primitive-Data-Types-and-Variables-Homework.docx

class EmployeeData
{
    static void Main()
    {
        Console.Title = "Problem 10. Employee Data";

        string FirstName = "Ivan";
        string LastName = "Ivanov";
        byte Age = 26;
        string Gender = "m";
        decimal PersonalIDNumber = 8306112507m;
        decimal UniqueEmployeeNumber = 275600027569999m;
        Console.WriteLine("First name: {0}", FirstName);
        Console.WriteLine("Last name: {0}", LastName);
        Console.WriteLine("Age: {0}", Age);
        Console.WriteLine("Gender: {0}", Gender);
        Console.WriteLine("Personal ID number: {0}", PersonalIDNumber);
        Console.WriteLine("Unique employee number: {0}", UniqueEmployeeNumber);
    }
}
