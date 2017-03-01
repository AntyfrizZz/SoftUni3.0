using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Startup
{
    static HashSet<string> semanticTags = new HashSet<string> { "main", "header", "nav", "article", "section", "aside", "footer" };

    static void Main()
    {
        var inputLine = Console.ReadLine();

        while (inputLine != "END")
        {
            var openPattern = @"(<div).*?\b((id|class)\s*=\s*""(.*?)"").*?>";

            var matches = Regex.Match(inputLine, openPattern);

            if (matches.Groups.Count > 1)
            {
                if (semanticTags.Contains(matches.Groups[4].ToString()))
                {
                    Regex regRepl = new Regex(matches.Groups[1].ToString());
                    inputLine = regRepl.Replace(inputLine, "<" + matches.Groups[4].ToString());

                    regRepl = new Regex(matches.Groups[2].ToString());
                    inputLine = regRepl.Replace(inputLine, "");

                    regRepl = new Regex(@"\s+");
                    inputLine = regRepl.Replace(inputLine, " ");

                    regRepl = new Regex(@"<\s+");
                    inputLine = regRepl.Replace(inputLine, "<");

                    regRepl = new Regex(@"\s+>");
                    inputLine = regRepl.Replace(inputLine, ">");
                }
            }

            var closePattern = @"<\/div>\s.*?(\w+)\s*-->";

            matches = Regex.Match(inputLine, closePattern);

            if (matches.Groups.Count > 1)
            {
                if (semanticTags.Contains(matches.Groups[1].ToString()))
                {
                    Regex regRepl = new Regex(matches.Groups[0].ToString());
                    inputLine = regRepl.Replace(inputLine, "</" + matches.Groups[1].ToString() + ">");

                }
            }

            Console.WriteLine(inputLine);
  


            inputLine = Console.ReadLine();
        }
    }
}