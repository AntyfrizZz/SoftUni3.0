using System;
using System.Numerics;
//Write a program that calculates n! / k! for given n and k (1 < k < n < 100). Use only one loop. 

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/6.%20Loops-Homework.docx

class Calculate
{
    static void Main()
    {
        Console.Title = "Problem 6.	Calculate N! / K!";

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

        BigInteger result = factorialN / factorialK;
        Console.WriteLine("n!/k! = {0}", result);
    }
}