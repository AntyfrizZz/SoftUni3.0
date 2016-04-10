using System;
//Write a program that enters 5 numbers (given in a single line, separated by a space), calculates and prints their sum.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/4.%20Console-Input-Output-Homework.docx

class SumOf5Numbers
{
    static void Main()
    {
        Console.Title = "Problem 7.	Sum of 5 Numbers";

        Console.Write("Enter 5 numbers (in single line, separated by a space): ");
        string[] userINput = Console.ReadLine().Split();
        double a = Convert.ToDouble(userINput[0]);
        double b = Convert.ToDouble(userINput[1]);
        double c = Convert.ToDouble(userINput[2]);
        double d = Convert.ToDouble(userINput[3]);
        double e = Convert.ToDouble(userINput[4]);

        double sumOfAll = a + b + c + d + e;
        Console.WriteLine(sumOfAll);
    }
}
