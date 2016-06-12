using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    public static void Main()
    {
//#if DEBUG
//        Console.SetIn(new StreamReader("../../../input.txt"));
//#endif
        var key = Console.ReadLine();
        var text = ReadText();

        var address = ExtractAddress(text, key);
        Console.WriteLine(address);
    }

    private static string ExtractAddress(string text, string key)
    {
        string pattern = ExtractPattern(key);
        var regex = new Regex(pattern);

        var addressBuilder = new StringBuilder();

        while (regex.IsMatch(text))
        {
            var match = regex.Match(text);
            string info = match.Groups["info"].ToString();

            int position = match.Index;
            if (info.Length >= 2 && info.Length <= 6)
            {
                addressBuilder.Append(info);
                position += match.Length;
            }
            else
            {
                position += match.Groups["startKey"].Length;
            }

            text = text.Substring(position);
        }

        return $"{addressBuilder}";
    }

    private static string ExtractPattern(string key)
    {
        var patternBuilder = new StringBuilder();
        patternBuilder.Append(Regex.Escape(key[0].ToString()));

        for (int index = 1; index < key.Length - 1; index++)
        {
            if (char.IsUpper(key[index]))
                patternBuilder.Append("[A-Z]*");
            else if (char.IsLower(key[index]))
                patternBuilder.Append("[a-z]*");
            else if (char.IsDigit(key[index]))
                patternBuilder.Append("\\d*");
            else
                patternBuilder.Append(Regex.Escape(key[index].ToString()));
        }

        patternBuilder.Append(Regex.Escape(key[key.Length - 1].ToString()));

        return $"(?'startKey'{patternBuilder})(?'info'.{{2,6}}){patternBuilder}";
    }

    private static string ReadText()
    {
        var text = new StringBuilder();
        var line = Console.ReadLine();

        while (line != "END")
        {
            text.Append(line);
            line = Console.ReadLine();
        }

        return text.ToString();
    }
}