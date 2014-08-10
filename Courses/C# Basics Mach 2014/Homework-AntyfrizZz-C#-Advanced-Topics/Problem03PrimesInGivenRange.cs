using System;
using System.Collections.Generic;
using System.Numerics;

//https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/7.%20CSharp-Advanced-Topics-Homework.docx

class PrimesInGivenRange
{
    static void Main()
    {
    A:
        int startNum = int.Parse(Console.ReadLine());
        int endNum = int.Parse(Console.ReadLine());

        List<int> primes = IsPrime(startNum, endNum);

        Console.WriteLine(String.Join(",", primes));
        
        goto A;
    }

    public static List<int> IsPrime(int start, int end)
    {
        List<int> primes = new List<int>();

        for (int num = start; num <= end; num++)
        {
            bool prime = true;
            int divider = 2;
            int maxDivider = (int)Math.Sqrt(num);
            while (divider <= maxDivider)
            {
                if (num % divider == 0)
                {
                    prime = false;
                    break;
                }
                divider++;
            }
            if (prime)
            {
                primes.Add(num);
            }
        }

        return primes;
    }
}