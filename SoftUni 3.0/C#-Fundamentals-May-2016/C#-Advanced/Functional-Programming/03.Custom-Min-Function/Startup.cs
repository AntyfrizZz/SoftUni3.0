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

        Func<int[], int> minValue = number => number.Min();

        Console.WriteLine(minValue(input));
        
    }
}