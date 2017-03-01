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
            var pattern = @"\+359( |-)2\1[0-9]{3}\1[0-9]{4}\b";
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
