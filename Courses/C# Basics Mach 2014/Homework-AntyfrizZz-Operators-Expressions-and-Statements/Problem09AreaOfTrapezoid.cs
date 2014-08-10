using System;
//Write an expression that calculates trapezoid's area by given sides a and b and height h.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/3.%20Operators-Expressions-and-Statements-Homework.docx

class AreaOfTrapezoid
{
    static void Main()
    {
        Console.Title = "Problem 9.	Trapezoids";

        Console.Write("Enter the first side of the trapezoid: ");
        double firstSide = double.Parse(Console.ReadLine());

        while (firstSide <= 0)
        {
            Console.Write("Please enter a positive number: ");
            firstSide = double.Parse(Console.ReadLine());
        }

        Console.Write("Enter the second side of the trapezoid: ");
        double secondSide = double.Parse(Console.ReadLine());

        while (secondSide <= 0)
        {
            Console.Write("Please enter a positive number: ");
            secondSide = double.Parse(Console.ReadLine());
        }

        Console.Write("Enter the height of the trapezoid: ");
        double height = double.Parse(Console.ReadLine());

        while (height <= 0)
        {
            Console.Write("Please enter a positive number: ");
            height = double.Parse(Console.ReadLine());
        }

        double trapezoidArea = height * (firstSide + secondSide) / 2;

        Console.WriteLine("The area of the trapezoid is " + trapezoidArea);
    }
}
