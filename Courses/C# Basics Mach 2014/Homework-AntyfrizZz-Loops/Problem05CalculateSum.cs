using System;
//Write a program that, for a given two integer numbers n and x, calculates the sum S = 1 + 1!/x + 2!/x2 + … + n!/xn.
//Use only one loop. Print the result with 5 digits after the decimal point.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/6.%20Loops-Homework.docx

class CalculateSum
{
    static void Main()
    {
        Console.Title = "Problem 5.	Calculate 1 + 1!/X + 2!/X2 + … + N!/XN";

        Console.Write("n = ");
        string consoleInputNString = Console.ReadLine();
        double consoleInputN = Convert.ToDouble(consoleInputNString);

        Console.Write("x = ");
        string consoleInputXString = Console.ReadLine();
        double consoleInputX = Convert.ToDouble(consoleInputXString);

        double factorial = 1;
        double result = 1;

        for (int i = 1; i <= consoleInputN; i++)
        {
            factorial *= i;
            double xPawN = Math.Pow(consoleInputX, i);
            result += factorial / xPawN;
        }

        Console.WriteLine("{0:F5}", result);
    }
}