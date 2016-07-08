using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Startup
{
    static void Main()
    {
        var pattern = @"[0-9]+";
        Regex rgx = new Regex(pattern);

        var inputLine = Console.ReadLine();

        MatchCollection matches = rgx.Matches(inputLine);

        var result = new List<string>();

        foreach (Match number in matches)
        {
            var num = int.Parse(number.ToString());
            var toAdd = $"0x{num.ToString("X4")}";
            result.Add(toAdd);
        }

        Console.WriteLine(string.Join("-", result));
    }
}