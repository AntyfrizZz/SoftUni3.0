using System;
using System.Linq;

class Startup
{
    static void Main()
    {
        var arr = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var command = Console.ReadLine();

        while (command != "end")
        {
            var args = command.Split();

            switch (args[0])
            {
                case "exchange":
                    var index = int.Parse(args[1]);

                    if (index < 0 || index >= arr.Length)
                    {
                        Console.WriteLine("Invalid index");
                        break;
                    }

                    arr = ExchangeArray(arr, index + 1);

                    break;
                case "max":
                case "min":
                    Console.WriteLine(GetIndex(arr, args[0], args[1]));
                    break;
                case "first":
                case "last":
                    Console.WriteLine(GetSequence(arr, int.Parse(args[1]), args[0], args[2]));
                    break;
            }
            command = Console.ReadLine();
        }

        Console.WriteLine($"[{string.Join(", ", arr)}]");
    }

    static int[] ExchangeArray(int[] arr, int index)
    {
        return arr.Skip(index).Concat(arr.Take(index)).ToArray();
    }

    static string GetIndex(int[] arr, string type, string parity)
    {
        var remainder = parity == "odd" ? 1 : 0;

        var filtered = arr.Where(n => n % 2 == remainder).ToArray();

        if (!filtered.Any())
        {
            return "No matches";
        }

        return type == "min"
            ? Array.LastIndexOf(arr, filtered.Min()).ToString()
            : Array.LastIndexOf(arr, filtered.Max()).ToString();
    }

    static string GetSequence(int[] arr, int count, string type, string parity)
    {
        if (count > arr.Length)
        {
            return "Invalid count";
        }

        var remainder = parity == "odd" ? 1 : 0;
        var filtered = arr.Where(n => n % 2 == remainder).ToArray();

        return type == "first"
            ? $"[{string.Join(", ", filtered.Take(count))}]"
            : $"[{string.Join(", ", filtered.Reverse().Take(count).Reverse())}]";
    }
}