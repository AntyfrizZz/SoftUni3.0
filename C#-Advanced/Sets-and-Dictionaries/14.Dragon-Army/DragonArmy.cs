using System;
using System.Collections.Generic;
using System.Text;

class DragonArmy
{
    static void Main()
    {
        var result = new Dictionary<string, SortedDictionary<string, List<double>>>();

        var numberOfDragons = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfDragons; i++)
        {
            var dragonArgs = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var dragonType = dragonArgs[0];
            var name = string.Empty;
            
            for (int j = 1; j < dragonArgs.Length - 3; j++)
            {
                name += dragonArgs[j] + " ";
            }

            name = name.Trim();

            double dmg;
            double health;
            double armor;

            bool isNumericDmg = double.TryParse(dragonArgs[dragonArgs.Length - 3], out dmg);
            bool isNumericHealth = double.TryParse(dragonArgs[dragonArgs.Length - 2], out health);
            bool isNumericArmor = double.TryParse(dragonArgs[dragonArgs.Length - 1], out armor);

            if (!isNumericDmg)
            {
                dmg = 45;
            }
            if (!isNumericHealth)
            {
                health = 250;
            }
            if (!isNumericArmor)
            {
                armor = 10;
            }

            var dragonStats = new List<double>();
            dragonStats.Add(dmg);
            dragonStats.Add(health);
            dragonStats.Add(armor);

            var dragon = new SortedDictionary<string, List<double>>();
            dragon.Add(name, dragonStats);

            if (!result.ContainsKey(dragonType))
            {
                result.Add(dragonType, dragon);
            }
            else
            {
                if (!result[dragonType].ContainsKey(name))
                {
                    result[dragonType].Add(name, dragonStats);
                }
                else
                {
                    result[dragonType][name] = dragonStats;
                }
                
            }           

            //Console.WriteLine("#" + name + "#");
            //Console.WriteLine(dmg);
            //Console.WriteLine(health);
            //Console.WriteLine(armor);
        }

        foreach (var kvp in result)
        {
            double averageDmg = 0;
            double averageHealth = 0;
            double averageArmor = 0;

            var allDragonsInType = new StringBuilder();

            foreach (var kvpInValue in kvp.Value)
            {
                averageDmg += kvpInValue.Value[0];
                averageHealth += kvpInValue.Value[1];
                averageArmor += kvpInValue.Value[2];

                allDragonsInType.AppendLine($"-{kvpInValue.Key} -> damage: {kvpInValue.Value[0]}, health: {kvpInValue.Value[1]}, armor: {kvpInValue.Value[2]}");
            }

            averageDmg /= kvp.Value.Count;
            averageHealth /= kvp.Value.Count;
            averageArmor /= kvp.Value.Count;

            Console.WriteLine("{0}::({1:0.00}/{2:0.00}/{3:0.00})", kvp.Key, averageDmg, averageHealth, averageArmor);
            Console.Write(allDragonsInType);
        }
    }
}
