using System;
using System.Collections.Generic;

class Startup
{
    static void Main()
    {
        var names = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var count = new int[names.Length];

        for (int i = 0; i < count.Length; i++)
        {
            count[i] = 1;
        }

        Predicate<string> remove = n => n.Equals("Remove");
        Predicate<string> doubled = n => n.Equals("Double");

        Predicate<string> startsWith = n => n.Equals("StartsWith");
        Predicate<string> endsWith = n => n.Equals("EndsWith");
        Predicate<string> length = n => n.Equals("Length");

        var commandArgs = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        while (commandArgs[0] != "Party!")
        {
            Predicate<string> ifStartsWith = n => n.IndexOf(commandArgs[2]) == 0;
            Predicate<string> ifEndsWith = n => n.LastIndexOf(commandArgs[2]) == n.Length - commandArgs[2].Length;
            Predicate<string> ifLength = n => n.Length == int.Parse((commandArgs[2]));

            if (remove(commandArgs[0]))
            {
                if (startsWith(commandArgs[1]))
                {
                    Remove(names, count, ifStartsWith);
                }
                else if (endsWith(commandArgs[1]))
                {
                    Remove(names, count, ifEndsWith);
                }
                else if (length(commandArgs[1]))
                {
                    Remove(names, count, ifLength);
                }
            }
            else if (doubled(commandArgs[0]))
            {
                if (startsWith(commandArgs[1]))
                {
                    Doubled(names, count, ifStartsWith);
                }
                else if (endsWith(commandArgs[1]))
                {
                    Doubled(names, count, ifEndsWith);
                }
                else if (length(commandArgs[1]))
                {
                    Doubled(names, count, ifLength);
                }
            }

            commandArgs = Console.ReadLine()
                 .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        }

        var result = new List<string>();

        for (int i = 0; i < names.Length; i++)
        {
            for (int j = 0; j < count[i]; j++)
            {
                result.Add(names[i]);
            }
        }

        if (result.Count > 0)
        {
            Console.WriteLine($"{string.Join(", ", result)} are going to the party!");
        }
        else
        {
            Console.WriteLine("Nobody is going to the party!");
        }
    }

    private static void Doubled(string[] names, int[] count, Predicate<string> ifStartsWith)
    {
        for (int i = 0; i < names.Length; i++)
        {
            if (ifStartsWith(names[i]) && count[i] != 0)
            {
                count[i] *= 2;
            }
        }
    }

    private static void Remove(string[] names, int[] count, Predicate<string> ifStartsWith)
    {
        for (int i = 0; i < names.Length; i++)
        {
            if (ifStartsWith(names[i]))
            {
                count[i] = 0;
            }
        }
    }
}