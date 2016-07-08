using System;
using System.Collections.Generic;
using System.Linq;

class BasicStackOperations
{
    static void Main()
    {
        string input = Console.ReadLine();

        var inputArgs = input
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var numbersToPush = inputArgs[0];
        var numbersTOPop = inputArgs[1];
        var isPresented = inputArgs[2];

        var stack = new Stack<int>();

        var stackNumbers = Console.ReadLine();

        var stackNumbersArr = stackNumbers
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        for (int i = 0; i < numbersToPush - numbersTOPop; i++)
        {
            stack.Push(stackNumbersArr[i]);
        }

        if (stack.Contains(isPresented))
        {
            Console.WriteLine("true");
        }
        else if (stack.Count < 1)
        {
            Console.WriteLine("0");
        }
        else
        {
            Console.WriteLine(stack.Min());
        }
    }
}