using System;
//Write a program that calculates the greatest common divisor (GCD) of given two integers a and b. Use the Euclidean algorithm (find it in Internet).

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/6.%20Loops-Homework.docx

class CalculateGCD
{
    static void Main()
    {
        Console.Title = "Problem 17.* Calculate GCD";

        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int remain = a % b;
        while (remain != 0)
        {
            a = b;
            b = remain;
            remain = a % b;
        }
        Console.WriteLine(Math.Abs(b));
    }
}