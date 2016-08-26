using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Startup
{
    public static void Main()
    {
        var plantingCoords = new HashSet<string>();
        var rows = new Dictionary<int, int>();
        var cols = new Dictionary<int, int>();
        var result = new StringBuilder();

        var dimencions = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        var input = Console.ReadLine();

        while (!input.Equals("Bloom Bloom Plow"))
        {
            plantingCoords.Add(input);

            var plantCoords = input
                .Split()
                .Select(int.Parse)
                .ToArray();

            if (!rows.ContainsKey(plantCoords[0]))
            {
                rows.Add(plantCoords[0], 0);
            }
            rows[plantCoords[0]]++;

            if (!cols.ContainsKey(plantCoords[1]))
            {
                cols.Add(plantCoords[1], 0);
            }
            cols[plantCoords[1]]++;

            input = Console.ReadLine();
        }

        for (int row = 0; row < dimencions[0]; row++)
        {
            for (int col = 0; col < dimencions[1]; col++)
            {
                if (plantingCoords.Contains($"{row} {col}"))
                {
                    var count = -1;
                    if (rows.ContainsKey(row))
                    {
                        count += rows[row];
                    }

                    if (cols.ContainsKey(col))
                    {
                        count += cols[col];
                    }

                    result.Append($"{count} ");
                }
                else
                {
                    var count = 0;
                    if (rows.ContainsKey(row))
                    {
                        count += rows[row];
                    }

                    if (cols.ContainsKey(col))
                    {
                        count += cols[col];
                    }

                    result.Append($"{count} ");
                }
            }

            result.AppendLine();
        }

        Console.Write(result);
    }
}
