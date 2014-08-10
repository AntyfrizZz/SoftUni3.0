using System;
//Write a program that reads 3 integer numbers from the console and prints their sum.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/4.%20Console-Input-Output-Homework.docx

class SumOf3Integers
{
    static void Main()
    {
        Console.Title = "Problem 1.	Sum of 3 Integers";

        Console.Write("Write the first number: ");
        double inputNumberFirst = double.Parse(Console.ReadLine());

        Console.Write("Write the first number: ");
        double inputNumberSecond = double.Parse(Console.ReadLine());

        Console.Write("Write the first number: ");
        double inputNumberThird = double.Parse(Console.ReadLine());

        double sum = inputNumberFirst + inputNumberSecond + inputNumberThird;

        Console.WriteLine("The sum of the numbers is: {0}", sum);
    }
}
