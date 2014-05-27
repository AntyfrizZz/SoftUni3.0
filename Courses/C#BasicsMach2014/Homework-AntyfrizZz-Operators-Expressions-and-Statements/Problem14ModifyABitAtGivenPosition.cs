using System;
//We are given an integer number n, a bit value v (v=0 or 1) and a position p.
//Write a sequence of operators (a few lines of C# code) that modifies n to hold 
//the value v at the position p from the binary representation of n while preserving 
//all other bits in n.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/3.%20Operators-Expressions-and-Statements-Homework.docx

class ModifyABitAtGivenPosition
{
    static void Main()
    {
        Console.Title = "Problem 14. Modify a Bit at Given Position";

        Console.Write("Enter a positive integer: ");
        int inputNumber = int.Parse(Console.ReadLine());

        while (inputNumber < 0)
        {
            Console.Write("Please enter a positive integer: ");
            inputNumber = int.Parse(Console.ReadLine());
        }

        Console.Write("Enter a value of the bit (0 or 1): ");
        int bitValue = int.Parse(Console.ReadLine());

        while (bitValue != 0 & bitValue != 1)
        {
            Console.Write("Please enter correct bit value (0 or 1): ");
            bitValue = int.Parse(Console.ReadLine());
        }

        Console.Write("Enter the position of the bit ");
        sbyte bitPosition = sbyte.Parse(Console.ReadLine());

        while (bitPosition < 0)
        {
            Console.Write("Please enter correct bit position: ");
            bitPosition = sbyte.Parse(Console.ReadLine());
        }

        int result;

        if (bitValue == 0)
        {
            int mask = ~(1 << bitPosition);
            result = inputNumber & mask;
        }
        else
        {
            int mask = 1 << bitPosition;
            result = inputNumber | mask;
        }

        string binaryNumber = Convert.ToString(inputNumber, 2).PadLeft(16, '0');
        string binaryResult = Convert.ToString(result, 2).PadLeft(16, '0');

        Console.WriteLine("The binary number is:                   " + binaryNumber);
        Console.WriteLine("The number with bid " + bitValue + " in position " + bitPosition + " is: " + binaryResult);
    }
}