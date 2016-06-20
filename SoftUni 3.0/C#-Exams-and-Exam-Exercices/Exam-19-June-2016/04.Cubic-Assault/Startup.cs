using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

class Startup
{
    static Dictionary<string, Dictionary<string, BigInteger>> result = new Dictionary<string, Dictionary<string, BigInteger>>();
    static BigInteger merge = 1000000;

    static void Main()
    {
        var inputLine = Console.ReadLine();

        while (!inputLine.Equals("Count em all"))
        {
            var inputArgs = Regex.Split(inputLine, " -> ");

            var regionName = inputArgs[0];
            var type = inputArgs[1];
            var count = BigInteger.Parse(inputArgs[2]);

            if (!result.ContainsKey(regionName))
            {
                result.Add(regionName, new Dictionary<string, BigInteger>());
                result[regionName].Add("Green", 0);
                result[regionName].Add("Red", 0);
                result[regionName].Add("Black", 0);
            }

            result[regionName][type] += count;

            if (result[regionName]["Green"] >= merge)
            {
                var addRed = result[regionName]["Green"] / merge;
                result[regionName]["Red"] += addRed;
                result[regionName]["Green"] = result[regionName]["Green"] % merge;
            }

            if (result[regionName]["Red"] >= merge)
            {
                var addBlack = result[regionName]["Red"] / merge;
                result[regionName]["Black"] += addBlack;
                result[regionName]["Red"] = result[regionName]["Red"] % merge;
            }

            inputLine = Console.ReadLine();
        }


        var orderedResult = result
            .OrderByDescending(black => black.Value["Black"])
            .ThenBy(names => names.Key.Length)
            .ThenBy(namesAlpha => namesAlpha.Key);

        var resultForPrint = new StringBuilder();

        foreach (var kvp in orderedResult)
        {
            resultForPrint.AppendLine(kvp.Key);

            var orderedMeteors = kvp.Value
                .OrderByDescending(pair => pair.Value)
                .ThenBy(name => name.Key);

            foreach (var orderedMeteor in orderedMeteors)
            {
                resultForPrint.AppendLine($"-> {orderedMeteor.Key} : {orderedMeteor.Value}");
            }
        }

        Console.Write(resultForPrint);
    }
}