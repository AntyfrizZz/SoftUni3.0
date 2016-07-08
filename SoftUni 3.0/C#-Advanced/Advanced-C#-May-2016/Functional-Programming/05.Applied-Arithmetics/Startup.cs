using System;
using System.Linq;

class Startup
{
    static void Main()
    {
        var input = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var command = Console.ReadLine();

        while (command != "end")
        {
            switch (command)
            {
                case "add":
                    Func<int, int> add = n => n + 1;
                    for (int i = 0; i < input.Length; i++)
                    {
                        input[i] = add(input[i]);
                    }
                    break;
                case "subtract":
                    Func<int, int> sub = n => n - 1;
                    for (int i = 0; i < input.Length; i++)
                    {
                        input[i] = sub(input[i]);
                    }
                    break;
                case "multiply":
                    Func<int, int> multiply = n => n * 2;
                    for (int i = 0; i < input.Length; i++)
                    {
                        input[i] = multiply(input[i]);
                    }
                    break;
                default:
                    Console.WriteLine(string.Join(" ", input));
                    break;
            }

            command = Console.ReadLine();
        }
    }
}