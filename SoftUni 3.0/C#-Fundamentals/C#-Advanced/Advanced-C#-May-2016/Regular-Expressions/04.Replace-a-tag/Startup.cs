using System;
using System.Text.RegularExpressions;

class Startup
{
    static void Main()
    {
        var input = Console.ReadLine();

        while (input != "end")
        {
            string pattern = @"<a(.*)>(\w+)<\/a>";

            string replace = @"[URL$1]$2[/URL]";

            var replaced = Regex.Replace(input, pattern, replace);

            Console.WriteLine(replaced);

            input = Console.ReadLine();
        }
    }
}