using System;
//Write a program that gets two numbers from the console and prints the greater of them. Try to implement this without if statements. 

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/4.%20Console-Input-Output-Homework.docx

class NumberComparer
{
    static void Main()
    {
        Console.Title = "Problem 4.	Number Comparer";

        Console.Write("Enter the first number: ");
        double firstNumber = double.Parse(Console.ReadLine());

        Console.Write("Enter the second number: ");
        double secondNumber = double.Parse(Console.ReadLine());

        Console.WriteLine(firstNumber > secondNumber ? "greater: {0}" : "greater: {1}", firstNumber, secondNumber);
    }
}
