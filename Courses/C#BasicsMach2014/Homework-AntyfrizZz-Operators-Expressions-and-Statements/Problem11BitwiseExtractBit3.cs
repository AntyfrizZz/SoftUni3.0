using System;
//Using bitwise operators, write an expression for finding the value of the bit #3 of a given unsigned integer.
//The bits are counted from right to left, starting from bit #0. The result of the expression should be either 1 or 0.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/3.%20Operators-Expressions-and-Statements-Homework.docx

class BitwiseExtractBit3
{
    static void Main()
    {
        Console.Title = "Problem 11. Bitwise: Extract Bit #3";

        Console.Write("Enter a positive integer: ");
        int inputNumber = int.Parse(Console.ReadLine());

        while (inputNumber < 0)
        {
            Console.Write("Please enter a positive integer: ");
            inputNumber = int.Parse(Console.ReadLine());
        }

        int moveRight = inputNumber >> 3;
        int bit = moveRight & 1;
        Console.WriteLine("bit #3 is " + bit);
    }
}
