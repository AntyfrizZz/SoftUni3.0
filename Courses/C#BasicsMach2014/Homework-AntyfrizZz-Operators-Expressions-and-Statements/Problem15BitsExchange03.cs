using System;
//Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.

class BitsExchange
{
    static void Main()
    {
        Console.Title = "Problem 15.* Bits Exchange";

        uint number;
        Console.Write("Enter a positive integer: ");
        bool inputNumber = uint.TryParse(Console.ReadLine(), out number);

        if (inputNumber)
        {            
            Console.Write(Convert.ToString(number, 2).PadLeft(32, '0'));
            Console.WriteLine(" - Binary representation of the number");

            number = ((~(7u << 24 | 7u << 3)) & number) | (((number & (7u << 3)) << 21) | ((number & (7u << 24)) >> 21));//Swap bits 3,4,5 with 24,25,26
                        
            Console.Write(Convert.ToString(number, 2).PadLeft(32, '0'));
            Console.WriteLine(" - Binary representation of the new number");
            Console.WriteLine("{0} - Decimal representation of the new number", number);
        }
        else
        {
            Console.WriteLine("Not a valid entry!");
        }
    }
}