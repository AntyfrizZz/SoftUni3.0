using System;
using System.Text;
using System.Text.RegularExpressions;

class Startup
{
    static void Main()
    {
        var input = Console.ReadLine();

        while (input != "end")
        {
            MatchCollection emails = Regex.Matches(input, @"(?<=\s|^)[a-z0-9A-Z]+[-._]*[a-z0-9A-Z]+@[a-z0-9A-Z]+([-][a-z0-9A-Z]+)*(\.[a-z0-9A-Z]+([-][a-z0-9A-Z]+)*)+");

            var result = new StringBuilder();

            foreach (Match email in emails)
            {
                result.AppendLine(email.ToString());
            }

            Console.Write(result);

            input = Console.ReadLine();
        }
    }
}