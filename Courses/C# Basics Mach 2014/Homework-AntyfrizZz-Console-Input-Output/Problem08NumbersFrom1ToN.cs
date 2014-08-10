using System;
//Write a program that reads an integer number n from the console and prints all the numbers in the interval [1..n], each on a single line. Note that you may need to use a for-loop. 

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/4.%20Console-Input-Output-Homework.docx

class NumbersFrom1ToN
{
    static void Main()
    {
        Console.Title = "Problem 8.	Numbers from 1 to n";

        Console.Write(@"Enter the integer number ""n"": ");
        int nNumber = int.Parse(Console.ReadLine());

        for (int i = 1; i < nNumber + 1; i++)
        {
            Console.WriteLine(i);
        }
    }
}
