using System;
using System.Collections.Generic;

class PeriodicTable
{
    static void Main()
    {
        var numberOfElements = int.Parse(Console.ReadLine());
        var result = new SortedSet<string>();

        for (int i = 0; i < numberOfElements; i++)
        {
            var currentElement = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in currentElement)
            {
                result.Add(item);
            }
        }

        foreach (var item in result)
        {
            Console.Write(item + " ");
        }
    }
}