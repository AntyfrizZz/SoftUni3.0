using System;

class Startup
{
    static void Main()
    {
        var inputArgs = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var character = (char)1;

        if (inputArgs[0].Length < inputArgs[1].Length)
        {
            inputArgs[0] = inputArgs[0].PadRight(inputArgs[1].Length, character);
        }
        if (inputArgs[1].Length < inputArgs[0].Length)
        {
            inputArgs[1] = inputArgs[1].PadRight(inputArgs[0].Length, (char)1);
        }

        var result = 0;

        for (int i = 0; i < inputArgs[0].Length; i++)
        {
            result += (int)inputArgs[0][i] * (int)inputArgs[1][i];
        }


        Console.WriteLine(result);
    }
}
