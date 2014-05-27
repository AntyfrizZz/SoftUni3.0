using System;
//Write a program that finds the biggest of three numbers.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/5.%20Conditional-Statements-Homework.docx

class TheBiggestOf3Numbers
{
    static void Main()
    {
        Console.Title = "Problem 5.	The Biggest of 3 Numbers";

        Console.Write(@"Write ""a"": ");
        double aNumber = double.Parse(Console.ReadLine());

        Console.Write(@"Write ""b"": ");
        double bNumber = double.Parse(Console.ReadLine());

        Console.Write(@"Write ""c"": ");
        double cNumber = double.Parse(Console.ReadLine());

        if ((aNumber >= bNumber) && (aNumber >= cNumber))
        {
            Console.WriteLine(aNumber);
        }
        if ((bNumber >= aNumber) && (bNumber >= cNumber))
        {
            Console.WriteLine(bNumber);
        }
        if ((cNumber >= aNumber) && (cNumber >= bNumber))
        {
            Console.WriteLine(cNumber);
        }  
    }
}