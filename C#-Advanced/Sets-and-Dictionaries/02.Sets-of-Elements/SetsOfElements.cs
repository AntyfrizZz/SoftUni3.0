using System;
using System.Collections.Generic;

class SetsOfElements
{
    static void Main()
    {
        var setsCount = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var firstSetCount = int.Parse(setsCount[0]);
        var secondSetCount = int.Parse(setsCount[1]);

        var firstSet = new HashSet<int>();
        var secondSet = new HashSet<int>();

        for (int i = 0; i < firstSetCount; i++)
        {
            var value = int.Parse(Console.ReadLine());

            firstSet.Add(value);
        }

        for (int i = 0; i < secondSetCount; i++)
        {
            var value = int.Parse(Console.ReadLine());

            secondSet.Add(value);
        }

        firstSet.IntersectWith(secondSet);

        foreach (var item in firstSet)
        {
            Console.Write(item + " ");
        }
    }
}