using System;
//Write a program that enters 3 integers n, min and max (min ≤ max) and prints n random numbers in the range [min...max]. 

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/6.%20Loops-Homework.docx

class RandomNumbersInGivenRange
{
    static void Main()
    {
        Console.Title = "Problem 11. Random Numbers in Given Range";

        Console.Write("n (n > 0) = ");
        int n = int.Parse(Console.ReadLine());

        while (n < 0)
        {
            Console.Write("n (n > 0) = ");
            n = int.Parse(Console.ReadLine());
        }

        Console.Write("min = ");
        int min = int.Parse(Console.ReadLine());
        Console.Write("max (max > min) = ");
        int max = int.Parse(Console.ReadLine());

        while (min > max)
        {
            Console.Write("max (max > min) = ");
            max = int.Parse(Console.ReadLine());
        }

        Random random = new Random();

        for (int i = 0; i < n; i++)
        {
            Console.Write(random.Next(min, max + 1) + " ");
        }

        Console.WriteLine();
    }
}