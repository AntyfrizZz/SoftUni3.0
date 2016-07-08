using System;
using System.Text.RegularExpressions;

class Startup
{
    static void Main()
    {        
        var keysString = Console.ReadLine();

        var keyPattern = @"(^[a-zA-Z_]+)[0-9].*[0-9]([a-zA-Z_]+$)";
        Regex rgx = new Regex(keyPattern);

        MatchCollection matches = rgx.Matches(keysString);

        if (matches.Count == 0)
        {
            Console.WriteLine("<p>A key is missing</p>");
            return;
        }

        var startKey = matches[0].Groups[1];
        var endKey = matches[0].Groups[2];

        var textPattern = $"{startKey}([0-9\\.]+){endKey}";
        var textString = Console.ReadLine();

        rgx = new Regex(textPattern);
        matches = rgx.Matches(textString);

        if (matches.Count == 0)
        {
            Console.WriteLine("<p>The total value is: <em>nothing</em></p>");
            return;
        }

        double result = 0.0;
        foreach (Match value in matches)
        {
            result += double.Parse(value.Groups[1].ToString());
        }

        Console.WriteLine($"<p>The total value is: <em>{result}</em></p>");
    }
}