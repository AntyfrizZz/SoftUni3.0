using System;
using System.Text.RegularExpressions;

class Startup
{
    static void Main()
    {
        var keyWord = Console.ReadLine();
        var text = Console.ReadLine();
        var pattern = string.Format(@"[^!.?]*?\b{0}\b.*?(\!|\.|\?)", keyWord);

        Regex rgx = new Regex(pattern);
        Match match = rgx.Match(text);

        while (match != Match.Empty)
        {
            Console.WriteLine(match.Value);
            match = match.NextMatch();
        }
    }
}
