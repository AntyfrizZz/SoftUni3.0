using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Startup
{
    static void Main()
    {
        var input = Console.ReadLine();
        var countryWins = new Dictionary<string, int>();
        var countryParticipants = new Dictionary<string, string>();

        while (input != "report")
        {
            var tokens = input.Split('|');
            var name = tokens[0].Trim();
            name = Regex.Replace(name, @"\s+", " ");
            var country = tokens[1].Trim();
            country = Regex.Replace(country, @"\s+", " ");

            if (countryWins.ContainsKey(country))
            {
                countryWins[country]++;
                countryParticipants[country] += "," + name;
            }
            else
            {
                countryWins.Add(country, 1);
                countryParticipants.Add(country, name);
            }
            input = Console.ReadLine();
        }

        var items = from pair in countryWins
                    orderby pair.Value descending
                    select pair;

        var result = new StringBuilder();

        foreach (KeyValuePair<string, int> pair in items)
        {
            List<string> numberOfParticipants = countryParticipants[pair.Key].Split(',').Distinct().ToList();
            result.AppendLine($"{pair.Key} ({numberOfParticipants.Count} participants): {pair.Value} wins");
        }

        Console.Write(result);
    }
}