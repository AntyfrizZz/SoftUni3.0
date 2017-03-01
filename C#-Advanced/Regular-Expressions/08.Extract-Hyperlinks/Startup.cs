using System;
using System.Text;
using System.Text.RegularExpressions;

class Startup
{
    static void Main()
    {
        var input = Console.ReadLine();
        var sb = new StringBuilder();
        var pattern = "<a\\s+(?:[^>]+\\s+)?href\\s*=\\s*(?:'(?<text>[^']*)'|\"(?<text>[^\"]*)\"|(?<text>[^\\s>]+))[^>]*>";

        while (input != "END")
        {
            sb.Append(input);
            input = Console.ReadLine();
        }

        var text = sb.ToString();

        Regex hypers = new Regex(pattern);
        MatchCollection matches = hypers.Matches(text);

        var result = new StringBuilder();

        foreach (Match item in matches)
        {
            result.AppendLine(item.Groups["text"].ToString());
        }

        Console.Write(result);
    }
}