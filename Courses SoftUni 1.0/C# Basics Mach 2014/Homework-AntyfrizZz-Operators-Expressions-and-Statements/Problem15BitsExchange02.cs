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

        long mask = 1;
        long mask3 = mask << 3;
        long mask4 = mask << 4;
        long mask5 = mask << 5;
        long mask24 = mask << 24;
        long mask25 = mask << 25;
        long mask26 = mask << 26;

        long invertMask3 = ~mask3;
        long invertMask4 = ~mask4;
        long invertMask5 = ~mask5;
        long invertMask24 = ~mask24;
        long invertMask25 = ~mask25;
        long invertMask26 = ~mask26;

        long result;

        result = inputNumber & invertMask3;
        result = result & invertMask4;
        result = result & invertMask5;
        result = result & invertMask24;
        result = result & invertMask25;
        result = result & invertMask26;

        bit3 = bit3 << 24;
        bit4 = bit4 << 25;
        bit5 = bit5 << 26;
        bit24 = bit24 << 3;
        bit25 = bit25 << 4;
        bit26 = bit26 << 5;

        result = result | bit3;
        result = result | bit4;
        result = result | bit5;
        result = result | bit24;
        result = result | bit25;
        result = result | bit26;
        
        string binaryNumber = Convert.ToString(inputNumber, 2).PadLeft(32, '0');
        string binaryResult = Convert.ToString(result, 2).PadLeft(32, '0');

        Console.WriteLine(binaryNumber + " - binary represation of the number.");
        Console.WriteLine(binaryResult + " - binary represation of the number with exchanged bits.");

        Console.WriteLine(inputNumber + " - Number.");
        Console.WriteLine(result + " - Number with exchanged bits.");
    }
}