using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

class Startup
{
    static void Main()
    {
//#if DEBUG
//        Console.SetIn(new StreamReader("../../../input.txt"));
//#endif
        var pattern = @"(?<![a-zA-Z])[A-Z]+(?![a-zA-Z])";
        Regex rgx = new Regex(pattern);

        var result = new StringBuilder();

        var input = Console.ReadLine();

        while (input != "END")
        {
            var prevIndex = 0;

            Match match = rgx.Match(input);

            while (match != Match.Empty)
            {
                result.Append(input.Substring(prevIndex, match.Index - prevIndex));
                var straigth = match.ToString();
                var reversed = Reverse(straigth);

                if (straigth.Equals(reversed))
                {
                    straigth = Doubling(straigth);
                    result.Append(straigth);
                }
                else
                {
                    result.Append(reversed);
                }
                prevIndex = match.Index + match.Length;
                match = match.NextMatch();
            }

            result.Append(input.Substring(prevIndex, input.Length - prevIndex));
            result.AppendLine();
            input = Console.ReadLine();
        }

        Console.Write(SecurityElement.Escape(result.ToString()));
    }

    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    private static string Doubling(string forDouble)
    {
        var result = new StringBuilder();

        for (int i = 0; i < forDouble.Length; i++)
        {
            result.Append(forDouble[i], 2);
        }

        return result.ToString();
    }
}