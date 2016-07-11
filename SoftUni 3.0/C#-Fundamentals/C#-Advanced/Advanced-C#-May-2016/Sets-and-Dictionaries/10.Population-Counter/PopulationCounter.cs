using System;
using System.Collections.Generic;
using System.Linq;

class PopulationCounter
{
    static void Main()
    {
        var input = Console.ReadLine();

        var result = new Dictionary<string, Dictionary<string, long>>();
        var countryPopilation = new Dictionary<string, long>();

        while (input != "report")
        {
            var inputArgs = input
          .Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            var city = inputArgs[0];
            var country = inputArgs[1];
            var population = long.Parse(inputArgs[2]);

            if (!result.ContainsKey(country))
            {
                var temp = new Dictionary<string, long>();
                temp.Add(city, population);

                result.Add(country, temp);
                countryPopilation.Add(country, population);
            }
            else
            {
                if (!result[country].ContainsKey(city))
                {
                    result[country].Add(city, 0);
                }

                result[country][city] += population;
                countryPopilation[country] += population;
            }

            input = Console.ReadLine();
        }

        var countryPopulationOrdered = countryPopilation.OrderByDescending(s => s.Value);

        foreach (var kvp in countryPopulationOrdered)
        {
            Console.WriteLine("{0} (total population: {1})", kvp.Key, kvp.Value);
            var orderedCities = result[kvp.Key].OrderByDescending(s => s.Value);

            foreach (var kvpInKey in orderedCities)
            {
                Console.WriteLine("=>{0}: {1}", kvpInKey.Key, kvpInKey.Value);
            }
        }
    }
}
