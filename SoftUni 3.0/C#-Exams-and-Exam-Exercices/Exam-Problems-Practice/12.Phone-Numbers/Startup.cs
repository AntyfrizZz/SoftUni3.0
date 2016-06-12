using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class Startup
{
    static List<Tuple<string, string>> result = new List<Tuple<string, string>>();

    static void Main()
    {
        var pattern = @"([A-Z][a-zA-Z]*)[^A-Za-z\+0-9]*(\+?[0-9][0-9\(\)\/\-\. ]*[0-9])";
        Regex rgx = new Regex(pattern);

        var input = string.Empty;
        var inputLine = Console.ReadLine();

        while (inputLine != "END")
        {
            input += inputLine;

            inputLine = Console.ReadLine();
        }

        MatchCollection matches = rgx.Matches(input);

        for (int i = 0; i < matches.Count; i++)
        {
            var name = matches[i].Groups[1].ToString();
            var numberWithSymbols = matches[i].Groups[2].ToString();
            var number = string.Empty;

            number = RemovingSymbols(numberWithSymbols, number);

            result.Add(new Tuple<string, string>(name, number));
        }


        if (result.Count > 0)
        {
            var sb = new StringBuilder();
            sb.Append("<ol>");

            foreach (var name in result)
            {
                sb.Append($"<li><b>{name.Item1}:</b> {name.Item2}</li>");
            }
            sb.Append("</ol>");
            Console.WriteLine(sb);
        }
        else
        {
            Console.WriteLine("<p>No matches!</p>");
        }
    }

    private static string RemovingSymbols(string numberWithSymbols, string number)
    {
        if (numberWithSymbols[0] == '+')
        {
            number += '+';
            for (int j = 1; j < numberWithSymbols.Length; j++)
            {
                if (Char.IsDigit(numberWithSymbols[j]))
                {
                    number += numberWithSymbols[j];
                }
            }
        }
        else
        {
            for (int j = 0; j < numberWithSymbols.Length; j++)
            {
                if (Char.IsDigit(numberWithSymbols[j]))
                {
                    number += numberWithSymbols[j];
                }
            }
        }

        return number;
    }
}