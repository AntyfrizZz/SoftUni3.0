using System;
using System.Collections.Generic;

class CountSymbols
{
    static void Main()
    {
        var input = Console.ReadLine();

        var result = new SortedDictionary<char, int>();

        foreach (var character in input)
        {
            if (!result.ContainsKey(character))
            {
                result.Add(character, 0);
            }
            result[character]++;
        }

        foreach (var item in result)
        {
            Console.WriteLine("{0}: {1} time/s", item.Key, item.Value);
        }
    }
}