using System;
using System.Collections.Generic;
using System.Linq;

class Startup
{
    static void Main()
    {
        var input = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var del = int.Parse(Console.ReadLine());

        Predicate<int> divisible = n => n % del == 0;

        var result = new List<int>();

        for (int i = input.Length - 1; i >= 0; i--)
        {
            if (!divisible(input[i]))
            {
                result.Add(input[i]);
            }
        }

        Console.WriteLine(string.Join(" ", result));
    }
}