using System;
using System.Text.RegularExpressions;

class Startup
{
    static void Main()
    {
        var input = Console.ReadLine();

        var pattern = "<p>(?<text>\\s*(.+?)\\s*)</p>";
        Regex rgx = new Regex(pattern);

        var result = string.Empty;

        MatchCollection matches = rgx.Matches(input);

        foreach (Match item in matches)
        {
            var temp = item.Groups["text"].ToString();

            Regex regRepl = new Regex(@"[^a-z0-9]");
            temp = regRepl.Replace(temp, " ");
            regRepl = new Regex(@"\s+");
            temp = regRepl.Replace(temp, " ");

            foreach (var character in temp)
            {
                if ((int)character > 96 && (int)character < 123)
                {
                    result += CharConvert(character);
                }
                else
                {
                    result += character;
                }
            }
        }

        Console.WriteLine(result);
    }

    static char CharConvert(char character)
    {
        int index = character;
        char characterTemp;

        if (index < 110)
        {
            index += 13;
            characterTemp = (char)index;
        }
        else
        {
            index -= 13;
            characterTemp = (char)index;
        }

        return characterTemp;
    }
}
