using System;
//Write an expression that extracts from given integer n the value of given bit at index p.

class ExtractBitFromInteger
{
    static void Main()
    {
        Console.Title = "Problem 12. Extract Bit from Integer";

        Console.Write("Enter a positive integer: ");
        int inputNumber = int.Parse(Console.ReadLine());

        while (inputNumber < 0)
        {
            Console.Write("Please enter a positive integer: ");
            inputNumber = int.Parse(Console.ReadLine());
        }

        Console.Write("Enter the position of the bit ");
        int bitPosition = int.Parse(Console.ReadLine());

        while (bitPosition < 0)
        {
            Console.Write("Please enter correct bit position: ");
            bitPosition = int.Parse(Console.ReadLine());
        }
                
        int nRightP = inputNumber >> bitPosition;
        int bit = nRightP & 1;
        Console.WriteLine("bit #" + bitPosition + " is " + bit);
    }
}
