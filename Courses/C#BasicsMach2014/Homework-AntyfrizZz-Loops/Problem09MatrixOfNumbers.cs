using System;
//Write a program that reads from the console a positive integer number n (1 ≤ n ≤ 20) and prints a matrix like in the examples below. Use two nested loops.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/6.%20Loops-Homework.docx

class MatrixOfNumbers
{
    static void Main()
    {
        Console.Title = "Problem 9.	Matrix of Numbers";

        Console.Write("n (0 <  n < 20) = ");
        string consoleInputNString = Console.ReadLine();
        int consoleInputN = Convert.ToInt32(consoleInputNString);

        while ((consoleInputN >= 20) || (0 > consoleInputN))
        {
            Console.Write("n (0 <  n < 20) = ");
            consoleInputNString = Console.ReadLine();
            consoleInputN = Convert.ToInt32(consoleInputNString);
        }

        for (int i = 1; i <= consoleInputN; i++)
        {
            for (int j = i; j < consoleInputN + i; j++)
            {
                Console.Write("{0,2} ", j);
            }
            Console.WriteLine();
        }
    }
}