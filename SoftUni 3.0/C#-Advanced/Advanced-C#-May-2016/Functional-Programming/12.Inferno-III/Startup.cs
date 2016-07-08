using System;
using System.Collections.Generic;
using System.Linq;

class Startup
{
    private static bool[] _excluded;
    static void Main()
    {
        var numbers = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        _excluded = new bool[numbers.Length];

        Predicate<string> sumLeft = s => s.Equals("Sum Left");
        Predicate<string> sumRight = s => s.Equals("Sum Right");
        Predicate<string> sumLeftRight = s => s.Equals("Sum Left Right");

        Func<int, int, int, bool> summingLeft = (sum, left, current) => sum == left + current;
        Func<int, int, int, bool> summingRight = (sum, right, current) => sum == current + right;
        Func<int, int, int, int, bool> summingLeftRight = (sum, left, right, current) => sum == left + current + right;

        var commandArgs = Console.ReadLine()
            .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        while (commandArgs[0] != "Forge")
        {
            var sum = int.Parse(commandArgs[2]);
            Predicate<string> command = s => s.Equals("Exclude");

            if (sumLeft(commandArgs[1]))
            {
                if (numbers.Length > 1)
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if (i == 0)
                        {
                            if (summingLeft(sum, 0, numbers[i]))
                            {
                                FillExcludedArray(commandArgs, command, i);
                            }
                        }
                        else
                        {
                            if (summingLeft(sum, numbers[i - 1], numbers[i]))
                            {
                                FillExcludedArray(commandArgs, command, i);
                            }
                        }
                    }
                }
                else
                {
                    if (summingLeft(sum, 0, numbers[0]))
                    {
                        FillExcludedArray(commandArgs, command, 0);
                    }
                }
            }
            else if (sumRight(commandArgs[1]))
            {
                if (numbers.Length > 1)
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if (i == numbers.Length - 1)
                        {
                            if (summingRight(sum, 0, numbers[i]))
                            {
                                FillExcludedArray(commandArgs, command, i);
                            }
                        }
                        else
                        {
                            if (summingLeft(sum, numbers[i + 1], numbers[i]))
                            {
                                FillExcludedArray(commandArgs, command, i);
                            }
                        }
                    }
                }
                else
                {
                    if (summingLeft(sum, 0, numbers[0]))
                    {
                        FillExcludedArray(commandArgs, command, 0);
                    }
                }
            }
            else if (sumLeftRight(commandArgs[1]))
            {
                if (numbers.Length > 1)
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        if (i == 0)
                        {
                            if (summingLeftRight(sum, 0, numbers[i + 1], numbers[i]))
                            {
                                FillExcludedArray(commandArgs, command, i);
                            }
                        }
                        else if (i == numbers.Length - 1)
                        {
                            if (summingLeftRight(sum, numbers[i - 1], 0, numbers[i]))
                            {
                                FillExcludedArray(commandArgs, command, i);
                            }
                        }
                        else
                        {
                            if (summingLeftRight(sum, numbers[i - 1], numbers[i + 1], numbers[i]))
                            {
                                FillExcludedArray(commandArgs, command, i);
                            }
                        }
                    }
                }
                else
                {
                    if (summingLeftRight(sum, 0, 0, numbers[0]))
                    {
                        FillExcludedArray(commandArgs, command, 0);
                    }
                }
            }

            commandArgs = Console.ReadLine()
            .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        }

        var result = new List<int>();

        for (int i = 0; i < numbers.Length; i++)
        {
            if (!_excluded[i])
            {
                result.Add(numbers[i]);
            }
        }

        Console.WriteLine(string.Join(" ", result));
    }

    private static void FillExcludedArray(string[] commandArgs, Predicate<string> command, int i)
    {
        if (command(commandArgs[0]))
        {
            _excluded[i] = true;
        }
        else
        {
            _excluded[i] = false;
        }
    }
}