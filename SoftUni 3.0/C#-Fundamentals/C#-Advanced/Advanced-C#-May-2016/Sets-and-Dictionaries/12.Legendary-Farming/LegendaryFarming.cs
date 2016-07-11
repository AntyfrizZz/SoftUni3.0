using System;
using System.Collections.Generic;
using System.Linq;

class LegendaryFarming
{
    static void Main()
    {
        var input = Console.ReadLine();

        var looting = true;
        var keyMaterials = new Dictionary<string, int>();
        keyMaterials.Add("shards", 0);
        keyMaterials.Add("fragments", 0);
        keyMaterials.Add("motes", 0);

        var junkMaterials = new SortedDictionary<string, int>();

        while (looting)
        {
            var inputArgs = input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var count = 0;
            var type = "wot";

            for (int i = 0; i < inputArgs.Length; i += 2)
            {
                count = int.Parse(inputArgs[i]);
                type = inputArgs[i + 1].ToLower();

                if (type == "shards" || type == "fragments" || type == "motes")
                {
                    keyMaterials[type] += count;

                    if (keyMaterials[type] >= 250)
                    {
                        looting = false;

                        if (type == "shards")
                        {
                            Console.WriteLine("Shadowmourne obtained!");
                            keyMaterials[type] -= 250;
                        }
                        else if (type == "fragments")
                        {
                            Console.WriteLine("Valanyr obtained!");
                            keyMaterials[type] -= 250;
                        }
                        else if (type == "motes")
                        {
                            Console.WriteLine("Dragonwrath obtained!");
                            keyMaterials[type] -= 250;
                        }
                    }
                }
                else
                {
                    if (!junkMaterials.ContainsKey(type))
                    {
                        junkMaterials.Add(type, 0);
                    }

                    junkMaterials[type] += count;
                }
                if (!looting)
                {
                    break;
                }
            }

            if (looting)
            {
                input = Console.ReadLine();
            }
        }

        var orderedKeyMaterials = keyMaterials
            .OrderByDescending(s => s.Value)
            .ThenBy(s => s.Key);

        foreach (var kvp in orderedKeyMaterials)
        {
            Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
        }

        foreach (var kvp in junkMaterials)
        {
            Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
        }

    }
}
