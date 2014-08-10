using System;
//Write a program that finds the biggest of five numbers by using only five if statements.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/5.%20Conditional-Statements-Homework.docx

class TheBiggestOfFiveNumbers
    {
        static void Main()
        {
            Console.Title = "Problem 6.	The Biggest of Five Numbers";

            Console.Write(@"Write ""a"": ");
            double aNumber = double.Parse(Console.ReadLine());

            Console.Write(@"Write ""b"": ");
            double bNumber = double.Parse(Console.ReadLine());

            Console.Write(@"Write ""c"": ");
            double cNumber = double.Parse(Console.ReadLine());

            Console.Write(@"Write ""d"": ");
            double dNumber = double.Parse(Console.ReadLine());

            Console.Write(@"Write ""e"": ");
            double eNumber = double.Parse(Console.ReadLine());

            if ((aNumber >= bNumber) && (aNumber >= cNumber) && (aNumber >= dNumber) && (aNumber >= eNumber))
            {
                Console.WriteLine(aNumber);
            }
            else if ((bNumber >= aNumber) && (bNumber >= cNumber) && (bNumber >= dNumber) && (bNumber >= eNumber))
            {
                Console.WriteLine(bNumber);
            }
            else if ((cNumber >= aNumber) && (cNumber >= bNumber) && (cNumber >= dNumber) && (cNumber >= eNumber))
            {
                Console.WriteLine(cNumber);
            }
            else if ((dNumber >= aNumber) && (dNumber >= bNumber) && (dNumber >= cNumber) && (dNumber >= eNumber))
            {
                Console.WriteLine(dNumber);
            }
            else if ((eNumber >= aNumber) && (eNumber >= bNumber) && (eNumber >= cNumber) && (eNumber >= dNumber))
            {
                Console.WriteLine(eNumber);
            }
        }
    }
