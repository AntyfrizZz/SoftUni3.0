using System;
//Write a Boolean expression that returns if the bit at position p (counting from 0, starting from the right) in given integer number n has value of 1.

class CheckABitAtGivenPosition
{
    static void Main()
    {
        Console.Title = "Problem 13. Check a Bit at Given Position";

        Console.Write("Enter a positive integer: ");
        int inputNumber = int.Parse(Console.ReadLine());

        while (inputNumber < 0)
        {
            Console.Write("Please enter a positive integer: ");
            inputNumber = int.Parse(Console.ReadLine());
        }

        Console.Write("Enter the position of the bit ");
        sbyte bitPosition = sbyte.Parse(Console.ReadLine());

        while (bitPosition < 0)
        {
            Console.Write("Please enter correct bit position: ");
            bitPosition = sbyte.Parse(Console.ReadLine());
        }

        int nRightP = inputNumber >> bitPosition;
        int bit = nRightP & 1;
        
        bool bitValue = bit == 1;

        Console.WriteLine("bit #" + bitPosition + " == 1: " + bitValue);
    }
}

//string binValue = Convert.ToString(inputNumber, 2);
//string binValue2 = Convert.ToString(1, 2);
//string binValue3 = Convert.ToString(nRightP, 2);
//string binValue4 = Convert.ToString(bit, 2);

//Console.WriteLine(binValue.PadLeft(16, '0'));
//Console.WriteLine(binValue3.PadLeft(16, '0'));
//Console.WriteLine(binValue2.PadLeft(16, '0'));
//Console.WriteLine(binValue4.PadLeft(16, '0'));