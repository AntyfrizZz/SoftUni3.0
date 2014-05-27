using System;
//Using loops write a program that converts a binary integer number to its decimal form. The input is entered as string.
//The output should be a variable of type long. Do not use the built-in .NET functionality. 

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/6.%20Loops-Homework.docx

class BinaryToDecimalNumber
{
    static void Main()
    {
        Console.Title = "Problem 13. Binary to Decimal Number";

        string input = Console.ReadLine();

        int lastIndex = input.Length - 1;
        long dec = 0;

        for (int i = 0; i < input.Length; i++, lastIndex--)
        {
            if (input[i].ToString().Contains("0"))
            {

            }
            else if (input[i].ToString().Contains("1"))
            {
                long binarySum = 1;
                for (int j = 0; j < lastIndex; j++)
                {
                    binarySum *= 2;
                }
                dec += binarySum;
            }
        }
        Console.WriteLine(dec);
    }
}