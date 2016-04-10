using System;
//Write a program that enters in integer n and prints the numbers 1, 2, …, n in random order.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/6.%20Loops-Homework.docx

class Program
{
    static void Main()
    {
        Console.Title = "Problem 12.* Randomize the Numbers 1…N";

        Console.Write("n (n > 0) = ");
        int n = int.Parse(Console.ReadLine());

        while (n < 0)
        {
            Console.Write("n (n > 0) = ");
            n = int.Parse(Console.ReadLine());
        }
               
        bool[] printed = new bool[n + 1];
        Random randomNum = new Random();
        int numberToPrint;
        for (int i = 1; i <= n; i++)
        {
            numberToPrint = randomNum.Next(1, n + 1);
            if (!printed[numberToPrint])
            {
                Console.Write(numberToPrint + " ");
                printed[numberToPrint] = true;
            }
            else
            {
                i--;
            }
        }

        Console.WriteLine();
    }
}