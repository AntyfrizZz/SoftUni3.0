using System;
using System.Numerics;
//Write a Boolean method IsPrime(n) that check whether a given integer number n is prime. 

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/7.%20CSharp-Advanced-Topics-Homework.docx

class PrimeChecker
{
    static void Main()
    {
        A:
        BigInteger inputNumber = BigInteger.Parse(Console.ReadLine());

        bool prime = IsPrime(inputNumber);
        Console.WriteLine(prime ? "true" : "false");

        goto A;
    }

    public static bool IsPrime(BigInteger candidate)
    {
        if ((candidate & 1) == 0)
        {
            if (candidate == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        for (BigInteger i = 3; (i * i) <= candidate; i += 2)
        {
            if ((candidate % i) == 0)
            {
                return false;
            }
        }
        return candidate != 1;
    }    
}