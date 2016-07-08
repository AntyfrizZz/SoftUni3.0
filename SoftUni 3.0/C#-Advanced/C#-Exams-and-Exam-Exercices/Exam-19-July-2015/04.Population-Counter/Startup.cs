using System;
using System.Collections.Generic;
using System.Linq;

class Startup
{
    public static void Main()
    {
        var populationData = new Dictionary<string, Dictionary<string, long>>();

        var input = Console.ReadLine();

        while (input != "report")
        {
            var data = input.Split('|');
            var country = data[1];
            var city = data[0];
            var population = int.Parse(data[2]);

            if (!populationData.ContainsKey(country))
            {
                populationData.Add(country, new Dictionary<string, long>());
            }

            populationData[country].Add(city, population);

            input = Console.ReadLine();
        }

        var sortedPopulationData = populationData
            .OrderByDescending(x => x.Value
                .Sum(y => y.Value));

        foreach (var countryInfo in sortedPopulationData)
        {
            var totalPopulation = countryInfo.Value.Sum(x => x.Value);
            Console.WriteLine($"{countryInfo.Key} (total population: {totalPopulation})");

            var orderedCityData = countryInfo.Value
                .OrderByDescending(x => x.Value);

            foreach (var cityInfo in orderedCityData)
            {
                Console.WriteLine($"=>{cityInfo.Key}: {cityInfo.Value}");
            }
        }
    }
}