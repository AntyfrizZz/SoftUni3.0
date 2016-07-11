using System;
using System.Text.RegularExpressions;

class Startup
{
    static void Main()
    {
        var input = Console.ReadLine();
        var pattern = @"\b([a-zA-Z]\w{2,24})\b";

        Regex rgx = new Regex(pattern);
        Match match = rgx.Match(input);

        var firstMatch = string.Empty;
        var secondMatch = string.Empty;
        var highestSum = 0;

        while (match != Match.Empty)
        {
            string firstMatchTemp = match.Value;
            int firstMatchLenght = match.Length;

            match = match.NextMatch();

            if (firstMatchLenght + match.Length > highestSum)
            {
                highestSum = firstMatchLenght + match.Length;
                firstMatch = firstMatchTemp;
                secondMatch = match.Value;
            }
        }

        Console.WriteLine(firstMatch);
        Console.WriteLine(secondMatch);
    }
}