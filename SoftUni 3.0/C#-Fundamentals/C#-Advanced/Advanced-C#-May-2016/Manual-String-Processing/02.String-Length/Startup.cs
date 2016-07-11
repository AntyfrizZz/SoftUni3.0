using System;

class Startup
{
    static void Main()
    {
        var input = Console.ReadLine();
        Console.WriteLine(StringCutter(input));
    }

    static string StringCutter(string input)
    {
        if (input.Length < 20)
        {
            input = input.PadRight(20, '*');
        }
        else if (input.Length > 20)
        {
            input = input.Substring(0, 20);
        }

        return input;
    }
}