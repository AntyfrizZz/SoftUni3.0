using System;
//Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/3.%20Operators-Expressions-and-Statements-Homework.docx

class BitsExchange
{
    static void Main()
    {
        Console.Title = "Problem 15.* Bits Exchange";

        Console.Write("Enter a positive integer: ");
        long inputNumber = long.Parse(Console.ReadLine());

        long nRight3 = inputNumber >> 3;
        long nRight4 = inputNumber >> 4;
        long nRight5 = inputNumber >> 5;
        long nRight24 = inputNumber >> 24;
        long nRight25 = inputNumber >> 25;
        long nRight26 = inputNumber >> 26;

        long bit3 = nRight3 & 1;
        long bit4 = nRight4 & 1;
        long bit5 = nRight5 & 1;
        long bit24 = nRight24 & 1;
        long bit25 = nRight25 & 1;
        long bit26 = nRight26 & 1;

        long result;
        long mask;


        if (bit3 == 0)
        {
            mask = ~(1 << 24);
            result = inputNumber & mask;
        }
        else
        {
            mask = 1 << 24;
            result = inputNumber | mask;
        }

        if (bit24 == 0)
        {
            mask = ~(1 << 3);
            result = result & mask;
        }
        else
        {
            mask = 1 << 3;
            result = result | mask;
        }


        if (bit4 == 0)
        {
            mask = ~(1 << 25);
            result = result & mask;
        }
        else
        {
            mask = 1 << 25;
            result = result | mask;
        }

        if (bit25 == 0)
        {
            mask = ~(1 << 4);
            result = result & mask;
        }
        else
        {
            mask = 1 << 4;
            result = result | mask;
        }


        if (bit5 == 0)
        {
            mask = ~(1 << 26);
            result = result & mask;
        }
        else
        {
            mask = 1 << 26;
            result = result | mask;
        }

        if (bit26 == 0)
        {
            mask = ~(1 << 5);
            result = result & mask;
        }
        else
        {
            mask = 1 << 5;
            result = result | mask;
        }


        string binaryNumber = Convert.ToString(inputNumber, 2).PadLeft(32, '0');
        string binarySecondResult = Convert.ToString(result, 2).PadLeft(32, '0');

        Console.WriteLine(binaryNumber + " - binary represation of the number.");
        Console.WriteLine(binarySecondResult + " - binary represation of the number with exchanged bits.");

        Console.WriteLine(inputNumber + " - Number.");
        Console.WriteLine(result + " - Number with exchanged bits.");
    }
}