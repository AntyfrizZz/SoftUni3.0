using System;
using System.Text.RegularExpressions;

class Startup
{
    static void Main()
    {
        var input = Console.ReadLine();
        System.Text.StringBuilder textSb = new System.Text.StringBuilder();
        System.Text.StringBuilder resultSb = new System.Text.StringBuilder();

        while (input != "burp")
        {
            textSb.Append(input);

            input = Console.ReadLine();
        }

        var text = Regex.Replace(textSb.ToString(), @"\s+", " "); ;

        var pattern = "(\\$[^\\$%\'\\&]+\\$|%[^\\$%\'\\&]+%|\'[^\\$%\'\\&]+\'|\\&[^\\$%\'\\&]+\\&)";
        Regex rgx = new Regex(pattern);

        MatchCollection matches = rgx.Matches(text);

        foreach (Match item in matches)
        {
            var word = item.ToString();

            for (int i = 1; i < word.Length - 1; i++)
            {
                var weight = (int)word[0] - 35;

                if (i % 2 == 1)
                {
                    var character = (int)word[i] + weight;
                    resultSb.Append((char)character);
                }
                else
                {
                    var character = (int)word[i] - weight;
                    resultSb.Append((char)character);
                }
            }

            resultSb.Append(' ');
        }

        Console.WriteLine(resultSb);
    }
}