using System;
using System.Collections.Generic;
using System.Linq;

class BasicQueueOperations
{
    static void Main()
    {
        string input = Console.ReadLine();

        var inputArgs = input
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var elementsToDeque = inputArgs[1];
        var isPresent = inputArgs[2];

        var elements = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var ourQueue = new Queue<int>();

        for (int i = elementsToDeque; i < elements.Length; i++)
        {
            ourQueue.Enqueue(elements[i]);
        }

        if (ourQueue.Contains(isPresent))
        {
            Console.WriteLine("true");
        }
        else if (ourQueue.Count < 1)
        {
            Console.WriteLine("0");
        }
        else
        {
            Console.WriteLine(ourQueue.Min());
        }
    }
}