using System;
//Using loops write a program that converts an integer number to its binary representation.
//The input is entered as long. The output should be a variable of type string. Do not use the built-in .NET functionality. 

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/6.%20Loops-Homework.docx

class DecimalToBinaryNumber
{
    static void Main()
    {
        Console.Title = "Problem 14. Decimal to Binary Number";

        Console.Write("Enter your decimal number: ");
        long dec = long.Parse(Console.ReadLine());

        long rest;
        string binary = string.Empty;

        while (dec > 0)
        {
            rest = dec % 2;
            dec /= 2;
            binary = rest.ToString() + binary;
        }

        Console.WriteLine(binary);
    }
}