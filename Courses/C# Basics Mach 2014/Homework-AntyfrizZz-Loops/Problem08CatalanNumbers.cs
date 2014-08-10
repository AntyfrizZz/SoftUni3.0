using System;
using System.Numerics;
//In combinatorics, the Catalan numbers are calculated by the following formula:
//Write a program to calculate the nth Catalan number by given n (1 < n < 100). Examples:

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/6.%20Loops-Homework.docx

class CatalanNumbers
{
    static void Main()
    {
        Console.Title = "Problem 8.	Catalan Numbers";

        Console.Write("n (0 <  n < 100) = ");
        string consoleInputNString = Console.ReadLine();
        BigInteger consoleInputN = Convert.ToInt64(consoleInputNString);

        while ((consoleInputN >= 100) || (0 > consoleInputN))
        {
            Console.Write("n (0 <  n < 100) = ");
            consoleInputNString = Console.ReadLine();
            consoleInputN = Convert.ToInt64(consoleInputNString);
        }

        BigInteger factorial2N = 1;
        BigInteger factorialN = 1;
        BigInteger factorialN1 = 1;

        for (BigInteger i = 1; i <= (consoleInputN * 2); i++)
        {
            factorial2N *= i;
        }

        for (BigInteger j = 1; j <= (consoleInputN + 1); j++)
        {
            factorialN1 *= j;
        }

        for (BigInteger k = 1; k <= consoleInputN; k++)
        {
            factorialN *= k;
        }

        BigInteger result = factorial2N / (factorialN1 * factorialN);
        Console.WriteLine("Catalan(n) = {0}", result);
    }
}