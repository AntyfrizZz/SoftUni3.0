using System;

class Startup
{
    static void Main()
    {
        var inputElemnts = Console.ReadLine()
            .Split(new[] { " ", "\n", "\t" }, StringSplitOptions.RemoveEmptyEntries);

        var result = 0m;

        foreach (var element in inputElemnts)
        {
            result += Calculating(element);
        }

        Console.WriteLine(result.ToString("F"));
    }

    static decimal Calculating(string input)
    {
        var number = decimal.Parse(input.Substring(1, input.Length - 2));
        var firstChar = input[0];
        var lastChar = input[input.Length - 1];

        if (char.IsLower(firstChar))
        {
            number *= char.ToUpper(firstChar) - 64;
        }
        else
        {
            number /= char.ToUpper(firstChar) - 64;
        }

        if (char.IsLower(lastChar))
        {
            number += char.ToUpper(lastChar) - 64;
        }
        else
        {
            number -= char.ToUpper(lastChar) - 64;
        }

        return number;
    }
}