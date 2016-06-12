using System;
using System.Collections.Generic;
using System.Text;

class Startup
{
    static SortedDictionary<string, string[]> personalInformation = new SortedDictionary<string, string[]>(); //<color, age/name
    static Dictionary<string, List<string>> opponents = new Dictionary<string, List<string>>(); //color, list of opponets
    static Dictionary<string, double[]> rank = new Dictionary<string, double[]>(); //color, wins/losts

    static void Main()
    {
        var input = Console.ReadLine();

        while (input != "END")
        {
            var inputArgs = input.Split('|');

            var color = inputArgs[0];

            if (!personalInformation.ContainsKey(color))
            {
                personalInformation.Add(color, new string[2]);
            }
            if (!opponents.ContainsKey(color))
            {
                opponents.Add(color, new List<string>());
            }
            if (!rank.ContainsKey(color))
            {
                rank.Add(color, new double[2]);
                rank[color][0] = 1;
                rank[color][1] = 1;
            }


            if (inputArgs[1] == "age")
            {
                personalInformation[color][0] = inputArgs[2];
            }
            else if (inputArgs[1] == "name")
            {
                personalInformation[color][1] = inputArgs[2];
            }
            else
            {
                opponents[color].Add(inputArgs[2]);

                if (inputArgs[1] == "win")
                {
                    rank[color][0]++;
                }
                else
                {
                    rank[color][1]++;
                }
            }

            input = Console.ReadLine();
        }

        var result = new StringBuilder();
        var noData = true;

        foreach (var kvp in personalInformation)
        {
            if (string.IsNullOrEmpty(kvp.Value[0]) || string.IsNullOrEmpty(kvp.Value[1]))
            {
                continue;
            }

            noData = false;

            result.AppendLine($"Color: {kvp.Key}");
            result.AppendLine($"-age: {kvp.Value[0]}");
            result.AppendLine($"-name: {kvp.Value[1]}");

            if (opponents[kvp.Key].Count == 0)
            {
                result.AppendLine($"-opponents: (empty)");
                result.AppendLine($"-rank: 1.00");
            }
            else
            {
                opponents[kvp.Key].Sort(StringComparer.Ordinal);
                result.AppendLine($"-opponents: {string.Join(", ", opponents[kvp.Key])}");
                result.AppendLine($"-rank: {rank[kvp.Key][0] / rank[kvp.Key][1]:0.00}");
            }
        }

        if (noData)
        {
            Console.WriteLine("No data recovered." );
        }
        else
        {
            Console.Write(result);
        }
       
    }
}