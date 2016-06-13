using System;
using System.Linq;
using System.Numerics;

class Startup
{
    static int index = 0;

    public static void Main()
    {
        var array = Console.ReadLine()
            .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(BigInteger.Parse)
            .ToArray();

        var command = Console.ReadLine();

        while (command != "stop")
        {
            var commandParams = command.Split();
            var offset = int.Parse(commandParams[0]) % array.Length;
            var operation = commandParams[1];
            var operand = int.Parse(commandParams[2]);

            if (offset < 0)
            {
                offset += array.Length;
            }

            index = (index + offset) % array.Length;

            PerformOperation(operation, array, operand);

            command = Console.ReadLine();
        }

        Console.WriteLine("[{0}]", string.Join(", ", array));
    }

    private static void PerformOperation(string operation, BigInteger[] array, int operand)
    {
        switch (operation)
        {
            case "&":
                array[index] &= operand;
                break;
            case "|":
                array[index] |= operand;
                break;
            case "^":
                array[index] ^= operand;
                break;
            case "+":
                array[index] += operand;
                break;
            case "-":
                array[index] -= operand;
                break;
            case "*":
                array[index] *= operand;
                break;
            case "/":
                array[index] /= operand;
                break;
        }

        if (array[index] < 0)
        {
            array[index] = 0;
        }
    }
}