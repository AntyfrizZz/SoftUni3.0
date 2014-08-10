using System;
//Write a program that enters from the console a positive integer n and prints all the numbers from 1 to n, on a single line, separated by a space.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/6.%20Loops-Homework.docx

class NumbersFrom1ToN
{
    static void Main()
    {
        Console.Title = "Problem 1.	Numbers from 1 to N";

        Console.Write("Enter a positive integer: ");
        int inputNum = int.Parse(Console.ReadLine());

        while (inputNum < 1)
        {
            Console.Write("Please enter a positive integer: ");
        inputNum = int.Parse(Console.ReadLine());
        }

        for (int i = 1; i <= inputNum; i++)
        {
            Console.Write(i);
            if (i == inputNum)
            {
                break;
            }
            Console.Write(" ");
        }
        Console.WriteLine();
    }
}