using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Startup
{
    static void Main()
    {
        var input = Console.ReadLine().ToUpper();
        var result = new StringBuilder();

        var pattern = "(?<text>\\D+)(?<digit>\\d+)";
        Regex rgx = new Regex(pattern);
        MatchCollection matches = rgx.Matches(input);

        foreach (Match item in matches)
        {
            var text = item.Groups["text"].ToString();
            var textRep = int.Parse(item.Groups["digit"].ToString());

            for (int i = 0; i < textRep; i++)
            {
                result.Append(text);
            }
        }

        var uniqueSymbols = result.ToString().Distinct().Count();

        Console.WriteLine("Unique symbols used: {0}", uniqueSymbols);
        Console.WriteLine(result);
    }
}