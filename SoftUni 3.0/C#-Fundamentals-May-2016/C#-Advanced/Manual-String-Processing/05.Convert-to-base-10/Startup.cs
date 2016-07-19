using System;
using System.Collections.Generic;
using System.Numerics;

class Startup
{
    static void Main()
    {
        var inputArgs = Console.ReadLine()
        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (inputArgs[0] == "10")
        {
            Console.WriteLine(inputArgs[1]);
            return;
        }

        inputArgs[1] = Reverse(inputArgs[1]);
        var paws = new Dictionary<BigInteger, BigInteger>();
        paws.Add(0, 1);

        BigInteger result = BigInteger.Parse(inputArgs[1][0].ToString());

        for (int i = 1; i < inputArgs[1].Length; i++)
        {
            paws.Add(i, BigInteger.Parse(inputArgs[0]) * paws[i - 1]);
            result += BigInteger.Parse(inputArgs[1][i].ToString()) * paws[i];
        }

        Console.WriteLine(result);
    }

    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
