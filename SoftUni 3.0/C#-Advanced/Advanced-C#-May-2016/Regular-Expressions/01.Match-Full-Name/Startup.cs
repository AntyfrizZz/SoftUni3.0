using System;
using System.Text;
using System.Text.RegularExpressions;

class Startup
{
    static void Main()
    {
        var result = new StringBuilder();

        var input = Console.ReadLine();

        while (input != "end")
        {
            var pattern = @"[A-Z][a-z]+ [A-Z][a-z]+";
            var regex = new Regex(pattern);

            if (regex.IsMatch(input))
            {
                result.AppendLine(input);
            }

            input = Console.ReadLine();
        }

        Console.Write(result);
    }
}