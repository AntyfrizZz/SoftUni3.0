using System;
using System.Collections.Generic;
using System.Linq;

class PoisonousPlants
{
    static int[] daySpan;
    static Stack<int> indexStack = new Stack<int>();

    static void Main()
    {
        var numberOfPlants = int.Parse(Console.ReadLine());
        var plants = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        daySpan = new int[numberOfPlants];
        daySpan[0] = -1;
        int min = plants[0];
        int minPlantIndex = 0;
        var maxSpan = 0;

        for (int i = 1; i < plants.Length; i++)
        {
            if (plants[i] <= min)
            {
                min = plants[i];
                minPlantIndex = i;
                daySpan[i] = -1;
                continue;
            }

            daySpan[i] = 1;

            for (int j = i - 1; j >= 0; j--)
            {
                if (plants[i] > plants[j])
                {
                    if (maxSpan < daySpan[i])
                    {
                        maxSpan = daySpan[i];
                    }
                    break;
                }
                else
                {
                    if (daySpan[j] >= daySpan[i])
                    {
                        daySpan[i] = daySpan[j] + 1;

                        if (maxSpan < daySpan[i])
                        {
                            maxSpan = daySpan[i];
                            break;
                        }
                    }
                }
            }
        }

        Console.WriteLine(maxSpan);

    }
}
