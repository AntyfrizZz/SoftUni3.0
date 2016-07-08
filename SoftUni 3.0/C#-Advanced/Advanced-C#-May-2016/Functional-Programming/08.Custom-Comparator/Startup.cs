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

        Predicate<int> isEven = n => n % 2 == 0;
        var even = new List<int>();
        var odd = new List<int>();

        for (int i = 0; i < input.Length; i++)
        {
            if (isEven(input[i]))
            {
                even.Add(input[i]);
            }
            else
            {
                odd.Add(input[i]);
            }
        }

        even.Sort();
        odd.Sort();

        Console.WriteLine($"{string.Join(" ", even)} {string.Join(" ", odd)}");

    }
}
