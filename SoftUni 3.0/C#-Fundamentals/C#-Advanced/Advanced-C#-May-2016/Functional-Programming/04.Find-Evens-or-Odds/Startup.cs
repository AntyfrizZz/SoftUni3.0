using System;
using System.Collections.Generic;
using System.Linq;

class Startup
{
    static void Main()
    {
        var inputArgs = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var command = Console.ReadLine();
        var result = new List<int>();

        if (command == "even")
        {
            Predicate<int> isEven = x => x % 2 == 0;

            for (int i = inputArgs[0]; i <= inputArgs[1]; i++)
            {
                if (isEven(i))
                {

                    for (int j = i; j <= inputArgs[1]; j += 2)
                    {
                        result.Add(j);
                    }
                    break;
                }
            }
        }
        else
        {
            Predicate<int> isOdd = x => x % 2 == 1 || x % 2 == -1;

            for (int i = inputArgs[0]; i <= inputArgs[1]; i++)
            {
                if (isOdd(i))
                {
                    for (int j = i; j <= inputArgs[1]; j += 2)
                    {
                        result.Add(j);
                    }
                    break;
                }
            }
        }

        Console.WriteLine(string.Join(" ", result));
    }
}