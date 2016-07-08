using System;
using System.Text;
using System.Text.RegularExpressions;

class Startup
{
    static void Main()
    {
        string input = Console.ReadLine();
        StringBuilder sb = new StringBuilder();
        string pattern = "<a\\s+(?:[^>]+\\s+)?href\\s*=\\s*(?:'(?<text>[^']*)'|\"(?<text>[^\"]*)\"|(?<text>[^\\s>]+))[^>]*>";

        while (input != "END")
        {
            sb.Append(input);
            input = Console.ReadLine();
        }

        string text = sb.ToString();

        Regex hypers = new Regex(pattern);
        MatchCollection matches = hypers.Matches(text);

        foreach (Match item in matches)
        {
            Console.WriteLine(item.Groups["text"]);
        }
    }
}