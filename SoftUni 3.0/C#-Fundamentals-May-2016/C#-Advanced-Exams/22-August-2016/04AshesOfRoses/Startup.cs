namespace ConsoleApplication2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Startup
    {
        public static void Main()
        {
            var result = new Dictionary<string, Dictionary<string, long>>();

            var pattern = @"^Grow\s<([A-Z][a-z]+)>\s<([a-zA-Z0-9]+)>\s([0-9]+)$";
            var rgx = new Regex(pattern);

            while (true)
            {
                var input = Console.ReadLine();

                if (input.Equals("Icarus, Ignite!"))
                {
                    break;
                }

                var match = rgx.Match(input);

                if (match.Success)
                {
                    var region = match.Groups[1].Value;
                    var color = match.Groups[2].Value;
                    var amount = long.Parse(match.Groups[3].Value);

                    if (!result.ContainsKey(region))
                    {
                        result.Add(region, new Dictionary<string, long>());
                    }

                    if (!result[region].ContainsKey(color))
                    {
                        result[region].Add(color, 0);
                    }

                    result[region][color] += amount;
                }
            }

            var ordered = result
                .OrderByDescending(a => a.Value.Values.Sum())
                .ThenBy(n => n.Key);

            var toPrint = new StringBuilder();

            foreach (var keyValuePair in ordered)
            {
                toPrint.AppendLine(keyValuePair.Key);

                var orderedColors = keyValuePair.Value
                    .OrderBy(a => a.Value)
                    .ThenBy(n => n.Key);

                foreach (var colors in orderedColors)
                {
                    toPrint.AppendLine($"*--{colors.Key} | {colors.Value}");
                }
            }

            if (result.Any())
            {
                Console.Write(toPrint);
            }
        }
    }
}
