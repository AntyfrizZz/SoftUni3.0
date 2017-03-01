using System;
using System.Collections.Generic;
using System.Numerics;

class RecursiveFibonacci
{
    static Dictionary<int, BigInteger> calculated = new Dictionary<int, BigInteger>();
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        calculated.Add(0, 0);
        calculated.Add(1, 1);
        calculated.Add(2, 1);

        BigInteger result = GetFibonachi(n);

        Console.WriteLine(result);

    }

    private static BigInteger GetFibonachi(int n)
    {

        if (calculated.ContainsKey(n))
        {
            return calculated[n];
        }
        else
        {
            calculated.Add(n, GetFibonachi(n - 1) + GetFibonachi(n - 2));
            return calculated[n];
        }
    }
}