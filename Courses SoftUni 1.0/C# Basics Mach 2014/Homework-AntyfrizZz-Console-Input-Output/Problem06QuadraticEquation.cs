using System;
//Write a program that reads the coefficients a, b and c of a quadratic equation ax2 + bx + c = 0 and solves it (prints its real roots).

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/4.%20Console-Input-Output-Homework.docx

class QuadraticEquation
{
    static void Main()
    {
        Console.Title = "Problem 6.	Quadratic Equation";

        Console.Write(@"Enter the coefficients ""a"": ");
        double aNumber = double.Parse(Console.ReadLine());

        Console.Write(@"Enter the coefficients ""b"": ");
        double bNumber = double.Parse(Console.ReadLine());

        Console.Write(@"Enter the coefficients ""c"": ");
        double cNumber = double.Parse(Console.ReadLine());

        double determine = bNumber * bNumber - (4 * aNumber * cNumber);
        double firstRoot;
        double secondRoot;

        if (determine < 0)
        {
            Console.WriteLine("no real roots");
        }
        else if (determine == 0)
	    {
            firstRoot = secondRoot = (-1 * bNumber) / (2 * aNumber);
            Console.WriteLine("x1 = x2 = {0}", firstRoot);
	    }
        else
	    {
            firstRoot = ((-1 * bNumber) - Math.Sqrt(determine)) / (2 * aNumber);
            secondRoot = ((-1 * bNumber) + Math.Sqrt(determine)) / (2 * aNumber);
            Console.WriteLine("x1 = {0}; x2 = {1}", firstRoot, secondRoot);
	    }
    }
}
