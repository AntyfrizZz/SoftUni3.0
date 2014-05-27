using System;
using System.Numerics;
//In combinatorics, the number of ways to choose k different members out of a group of n different elements (also known as the number of combinations) is calculated by the following formula:

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/6.%20Loops-Homework.docx

class CalculateCombinations
{
    static void Main()
    {
        Console.Title = "Problem 7.	Calculate N! / (K! * (N-K)!)";

        Console.Write("n (1 <  n < 100) = ");
        string consoleInputNString = Console.ReadLine();
        BigInteger consoleInputN = Convert.ToInt64(consoleInputNString);

        while ((consoleInputN >= 100) || (1 >= consoleInputN))
        {
            Console.Write("n (1 <  n < 100) = ");
            consoleInputNString = Console.ReadLine();
            consoleInputN = Convert.ToInt64(consoleInputNString);
        }

        Console.Write("k (1 < k < n < 100) = ");
        string consoleInputKString = Console.ReadLine();
        BigInteger consoleInputK = Convert.ToInt64(consoleInputKString);

        while ((1 >= consoleInputK) || (consoleInputN <= consoleInputK))
        {
            Console.Write("k (1 < k < n < 100) = ");
            consoleInputKString = Console.ReadLine();
            consoleInputK = Convert.ToInt64(consoleInputKString);
        }

        BigInteger factorialN = 1;
        BigInteger factorialK = 1;
        BigInteger factorialNK = 1;

        for (BigInteger i = 1, j = consoleInputK; i <= consoleInputN; i++, j--)
        {
            factorialN *= i;

            if (j > 1)
            {
                factorialK *= j;
            }
            else
            {
                factorialK = factorialK;
            }
        }

        for (BigInteger k = 1; k <= consoleInputN - consoleInputK; k++)
        {
            factorialNK *= k;
        }

        BigInteger result = factorialN / (factorialK * factorialNK);
        Console.WriteLine(result);
    }
}