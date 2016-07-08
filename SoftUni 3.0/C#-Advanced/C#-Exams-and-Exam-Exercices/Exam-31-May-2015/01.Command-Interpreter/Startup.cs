using System;
using System.Collections.Generic;
using System.Linq;

class Startup
{
    static void Main()
    { 
        var collection = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        var command = Console.ReadLine();

        while (command != "end")
        {
            try
            {
                ExecuteCommand(command.Split(), collection);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid input parameters.");
            }

            command = Console.ReadLine();
        }

        Console.WriteLine($"[{string.Join(", ", collection)}]");
    }

    private static void ExecuteCommand(string[] commandArgs, List<string> collection)
    {
        var operation = commandArgs[0];

        switch (operation)
        {
            case "reverse":
                ExecuteReverseCommand(commandArgs, collection);
                break;
            case "sort":
                ExecuteSortCommand(commandArgs, collection);
                break;
            case "rollLeft":
                ExecuteRollLeftCommand(commandArgs, collection);
                break;
            case "rollRight":
                ExecuteRollRightCommand(commandArgs, collection);
                break;
        }
    }

    private static void ExecuteRollRightCommand(string[] commandArgs, List<string> collection)
    {
        var numberOfRolls = int.Parse(commandArgs[1]) % collection.Count;

        var elementsToMove = collection
            .Skip(collection.Count - numberOfRolls)
            .Take(numberOfRolls)
            .ToArray();

        collection.InsertRange(0, elementsToMove);
        collection.RemoveRange(collection.Count - numberOfRolls, numberOfRolls);
    }

    private static void ExecuteRollLeftCommand(string[] commandArgs, List<string> collection)
    {
        var numberOfRolls = int.Parse(commandArgs[1]) % collection.Count;

        var elementsToMove = collection
            .Take(numberOfRolls)
            .ToArray();

        collection.AddRange(elementsToMove);
        collection.RemoveRange(0, numberOfRolls);
    }

    private static void ExecuteSortCommand(string[] commandArgs, List<string> collection)
    {
        var startIndex = int.Parse(commandArgs[2]);

        // startIndex == collection.Length - 1 && count == 0 does not throw exception; throw it manually
        if (startIndex == collection.Count)
        {
            throw new ArgumentException();
        }

        var count = int.Parse(commandArgs[4]);

        collection.Sort(startIndex, count, StringComparer.InvariantCulture);
    }

    private static void ExecuteReverseCommand(string[] commandArgs, List<string> collection)
    {
        var startIndex = int.Parse(commandArgs[2]);

        // startIndex == collection.Length - 1 && count == 0 does not throw exception; throw it manually
        if (startIndex == collection.Count)
        {
            throw new ArgumentException();
        }

        var count = int.Parse(commandArgs[4]);

        collection.Reverse(startIndex, count);
    }
}