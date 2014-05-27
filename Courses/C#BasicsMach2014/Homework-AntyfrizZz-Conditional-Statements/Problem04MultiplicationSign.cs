using System;
//Write a program that shows the sign (+, - or 0) of the product of three real numbers, without calculating it. Use a sequence of if operators.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/5.%20Conditional-Statements-Homework.docx

class MultiplicationSign
{
    static void Main()
    {
        Console.Title = "Problem 4.	Multiplication Sign";

        Console.Write(@"Write ""a"": ");
        double aNumber = double.Parse(Console.ReadLine());

        Console.Write(@"Write ""b"": ");
        double bNumber = double.Parse(Console.ReadLine());

        Console.Write(@"Write ""c"": ");
        double cNumber = double.Parse(Console.ReadLine());

        if (aNumber < 0)
        {
            if (bNumber < 0)
            {
                if (cNumber < 0)
                {
                    Console.WriteLine("-");
                }
                else if (cNumber > 0)
                {
                    Console.WriteLine("+");
                }
                else
                {
                    Console.WriteLine("0");
                }
            }
            else if (bNumber > 0)
            {
                if (cNumber < 0)
                {
                    Console.WriteLine("+");
                }
                else if (cNumber > 0)
                {
                    Console.WriteLine("-");
                }
                else
                {
                    Console.WriteLine("0");
                }
            }
            else
            {
                Console.WriteLine("0");
            }
        }
        else if (aNumber > 0)
        {
            if (bNumber < 0)
            {
                if (cNumber < 0)
                {
                    Console.WriteLine("+");
                }
                else if (cNumber > 0)
                {
                    Console.WriteLine("-");
                }
                else
                {
                    Console.WriteLine("0");
                }
            }
            else if (bNumber > 0)
            {
                if (cNumber < 0)
                {
                    Console.WriteLine("-");
                }
                else if (cNumber > 0)
                {
                    Console.WriteLine("+");
                }
                else
                {
                    Console.WriteLine("0");
                }
            }
            else
            {
                Console.WriteLine("0");
            }
        }
        else
	    {
            Console.WriteLine("0");
	    }
    }
}