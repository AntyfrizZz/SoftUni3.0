using System;
//Write a program that reads a number n and prints on the console the first n members of the Fibonacci sequence 
//(at a single line, separated by spaces) : 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, …. Note that you may need to learn how to use loops.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/4.%20Console-Input-Output-Homework.docx

class FibonacciNumbers
{
    static void Main()
    {
        Console.Title = "Problem 10. Fibonacci Numbers";

        Console.Write(@"Enter the number ""n"": ");
        int n = int.Parse(Console.ReadLine());

        int firstNum = 0;
        int secondNum = 1;
        int nextNum;

        Console.Write(firstNum + " " + secondNum + " ");

        for (int i = 0; i < n - 2; i++)
        {
            nextNum = firstNum + secondNum;
            firstNum = secondNum;
            secondNum = nextNum;

            Console.Write(nextNum + " ");
        }
    }
}
