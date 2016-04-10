using System;
//Write a program that reads 3 numbers: an integer a (0 ≤ a ≤ 500), a floating-point b and a floating-point c and prints them in 4 virtual columns on the console.
//Each column should have a width of 10 characters. The number a should be printed in hexadecimal, left aligned; then the number a should be printed in binary form,
//padded with zeroes, then the number b should be printed with 2 digits after the decimal point, 
//right aligned; the number c should be printed with 3 digits after the decimal point, left aligned.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/4.%20Console-Input-Output-Homework.docx

class FormattingNumbers
{
    static void Main()
    {
        Console.Title = "Problem 5.	Formatting Numbers";

        Console.Write(@"Enter an integer ""a"" (0 < a < 500): ");
        int aNumber = int.Parse(Console.ReadLine());

        while (aNumber < 0 || aNumber > 500)
        {
            Console.Write(@"Enter a valid integer ""a"" (0 < a < 500): ");
            aNumber = int.Parse(Console.ReadLine());
        }

        Console.Write(@"Enter an integer ""b"": ");
        float bNumber = float.Parse(Console.ReadLine());

        Console.Write(@"Enter an integer ""c"": ");
        float cNumber = float.Parse(Console.ReadLine());

        string binaryANumber = Convert.ToString(aNumber, 2).PadLeft(10, '0');

        Console.WriteLine("|{0,-10:X}|{1}|{2,10:0.00}|{3,-10:0.000}|", aNumber, binaryANumber, bNumber, cNumber);
    }
}
