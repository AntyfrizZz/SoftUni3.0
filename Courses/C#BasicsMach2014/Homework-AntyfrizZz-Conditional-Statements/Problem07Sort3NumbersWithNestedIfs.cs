using System;
//Write a program that enters 3 real numbers and prints them sorted in descending order. Use nested if statements. Don’t use arrays and the built-in sorting functionality.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/5.%20Conditional-Statements-Homework.docx

class Sort3NumbersWithNestedIfs
{
    static void Main()
    {
        Console.Title = "Problem 7.	Sort 3 Numbers with Nested Ifs";

        Console.Write(@"Write ""a"": ");
        double aNumber = double.Parse(Console.ReadLine());

        Console.Write(@"Write ""b"": ");
        double bNumber = double.Parse(Console.ReadLine());

        Console.Write(@"Write ""c"": ");
        double cNumber = double.Parse(Console.ReadLine());

        if ((aNumber > bNumber) && (aNumber > cNumber) && (bNumber != cNumber))
        {            
            if (bNumber > cNumber)
            {
                Console.WriteLine("{0} {1} {2}", aNumber, bNumber, cNumber); 
            }
            else if (cNumber > bNumber)
            {
                Console.WriteLine("{0} {1} {2}", aNumber, cNumber, bNumber); 
            }
        }
        else if ((bNumber > aNumber) && (bNumber > cNumber) && (aNumber != cNumber))
        {
            if (aNumber > cNumber)
            {
                Console.WriteLine("{0} {1} {2}", bNumber, aNumber, cNumber);
            }
            else if (cNumber > aNumber)
            {
                Console.WriteLine("{0} {1} {2}", bNumber, cNumber, aNumber);
            }
        }
        else if ((cNumber > aNumber) && (cNumber > bNumber) && (aNumber != bNumber))
        {
            if (aNumber > bNumber)
            {
                Console.WriteLine("{0} {1} {2}", cNumber, aNumber, bNumber);
            }
            else if (bNumber > aNumber)
            {
                Console.WriteLine("{0} {1} {2}", cNumber, bNumber, aNumber);
            }
        }
        else if ((aNumber == bNumber) && (aNumber != cNumber))
        {
            if (aNumber > cNumber)
            {
                Console.WriteLine("{0} {1} {2}", aNumber, bNumber, cNumber);
            }
            else if (aNumber < cNumber)
            {
                Console.WriteLine("{0} {1} {2}", cNumber, aNumber, bNumber);
            }
        }
        else if ((aNumber == cNumber) && (aNumber != bNumber))
        {
            if (aNumber > bNumber)
            {
                Console.WriteLine("{0} {1} {2}", aNumber, cNumber, bNumber);
            }
            else if (aNumber < bNumber)
            {
                Console.WriteLine("{0} {1} {2}", bNumber, aNumber, cNumber);
            }
        }
        else if ((bNumber == cNumber) && (bNumber != aNumber))
        {
            if (bNumber > aNumber)
            {
                Console.WriteLine("{0} {1} {2}", bNumber, cNumber, aNumber);
            }
            else if (bNumber < aNumber)
            {
                Console.WriteLine("{0} {1} {2}", aNumber, bNumber, cNumber);
            }
        }
        else
        {
            Console.WriteLine("{0} {1} {2}", aNumber, bNumber, cNumber);
        }
    }
}