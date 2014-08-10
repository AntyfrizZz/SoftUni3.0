using System;
//Write an if-statement that takes two integer variables a and b and exchanges their values if the first one is greater than the second one.
//As a result print the values a and b, separated by a space.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/5.%20Conditional-Statements-Homework.docx

class ExchangeIfGreater
{
    static void Main()
    {
        Console.Title = "Problem 1.	Exchange If Greater";

        Console.Write(@"Write ""a"": ");
        double aNumber = double.Parse(Console.ReadLine());

        Console.Write(@"Write ""b"": ");
        double bNumber = double.Parse(Console.ReadLine());

        double cNumber = aNumber;

        if (aNumber > bNumber)
        {
            aNumber = bNumber;
            bNumber = cNumber;
            Console.WriteLine("{0} {1}", aNumber, bNumber);
        }
        else
        {
            Console.WriteLine("{0} {1}", aNumber, bNumber);
        }
    }
}