using System;
//Write a program that exchanges bits {p, p+1, …, p+k-1} with bits {q, q+1, …, q+k-1} of a given 32-bit unsigned integer.
//The first and the second sequence of bits may not overlap.

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/3.%20Operators-Expressions-and-Statements-Homework.docx

class BitExchangeAdvanced
{
    static void Main()
    {
        Console.Title = "Problem 16.** Bit Exchange (Advanced)";

        uint n;
        byte p, q, k;
        Console.Write("Enter the unsigned integer number n:");
        bool isnInt = uint.TryParse(Console.ReadLine(), out n);
        Console.Write("Enter the start position of the first bit sequence p:");
        bool ispByte = byte.TryParse(Console.ReadLine(), out p);
        Console.Write("Enter the start position of the second bit sequence q:");
        bool isqByte = byte.TryParse(Console.ReadLine(), out q);
        Console.Write("Enter the lenght of the sequence k:");
        bool iskByte = byte.TryParse(Console.ReadLine(), out k);

        if (isnInt & ispByte & isqByte & iskByte)
        {
            if ((p + k) < 33 && (q + k) < 33 && (Math.Abs(p - q) >= k))
            {
                if (p > q)
                {
                    byte temp = q;
                    q = p;
                    p = temp;
                }                
                Console.Write(Convert.ToString(n, 2).PadLeft(32, '0'));
                Console.WriteLine(" - Binary representation of the number");

                n = ((~(((uint)Math.Pow(2, k) - 1) << q | ((uint)Math.Pow(2, k) - 1) << p)) & n) | (((n & (((uint)Math.Pow(2, k) - 1) << p)) << (Math.Abs(p - q))) | ((n & (((uint)Math.Pow(2, k) - 1) << q)) >> (Math.Abs(p - q))));//Swap bits p with bits q
                Console.Write(Convert.ToString(n, 2).PadLeft(32, '0'));
                Console.WriteLine(" - Binary representation the new number");
                Console.WriteLine("{0} - Decimal representation of the new number", n);
            }
            else
            {
                Console.WriteLine("Not a valid entry!");
            }
        }
        else
        {
            Console.WriteLine("Not a valid entry!");
        }
    }
}
