using System;
//Write a program that enters a number n and after that enters more n numbers and calculates and prints their sum. Note that you may need to use a for-loop.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/4.%20Console-Input-Output-Homework.docx

class SumOfNNumbers
{
    static void Main()
    {
        Console.Title = "Problem 9.	Sum of n Numbers";

        Console.Write(@"Enter the number ""n"": ");
        double nNumber = double.Parse(Console.ReadLine());
        double sum = 0;

        string[] userINput = Console.ReadLine().Split();

        for (int i = 0; i < nNumber; i++)
        {
            double a = decimal.Parse(Console.ReadLine());
            sum += a;            
        }

        Console.WriteLine(sum);
    }
}
