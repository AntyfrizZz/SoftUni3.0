using System;
using System.Collections.Generic;
using System.Numerics;

class AMinerTask
{
    static void Main()
    {
        var resources = new Dictionary<string, BigInteger>();

        var resource = Console.ReadLine();

        if (resource == "stop")
        {
            return;
        }

        var amount = BigInteger.Parse(Console.ReadLine());        

        while (true)
        {
            if (!resources.ContainsKey(resource))
            {
                resources.Add(resource, 0);
            }

            resources[resource] += amount;

            resource = Console.ReadLine();

            if (resource == "stop")
            {
                break;
            }

            amount = BigInteger.Parse(Console.ReadLine());
        }

        foreach (var kvp in resources)
        {
            Console.WriteLine("{0} -> {1}", kvp.Key, kvp.Value);
        }
    }
}