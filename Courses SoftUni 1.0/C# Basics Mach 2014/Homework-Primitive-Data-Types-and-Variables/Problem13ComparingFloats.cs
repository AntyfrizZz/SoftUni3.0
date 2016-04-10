using System;
//Write a program that safely compares floating-point numbers (double) with precision eps = 0.000001.
//Note that we cannot directly compare two floating-point numbers a and b by a==b because of the nature of the floating-point arithmetic.
//Therefore, we assume two numbers are equal if they are more closely to each other than a fixed constant eps

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/2.%20Primitive-Data-Types-and-Variables-Homework.docx

class ComparingFloats
{
    static void Main()
    {
        Console.Title = "Problem 13. Comparing Floats";

        Console.WriteLine("Enter the first number: ");
        double firstNum = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter the second number: ");
        double secondNum = double.Parse(Console.ReadLine());

        bool compare = (Math.Abs(firstNum - secondNum) < 0.000001);

        Console.WriteLine();

        if (compare)
        {
            Console.WriteLine((compare) + ": Numbers are equal with a precision of 0.000001.");
        }
        else
        {
            Console.WriteLine((compare) + ": Numbers are not equal with a precision of 0.000001.");
        }
    }
}
