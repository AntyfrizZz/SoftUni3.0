using System;
using System.Collections.Generic;
using System.Linq;

class Startup
{
    static int destroyedBunkers = 0;

    static void Main()
    {
        var areaDimensions = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var areaRows = areaDimensions[0];
        var areaCols = areaDimensions[1];

        var area = new int[areaRows][];

        FillArea(areaRows, area);

        CeaseFire(areaRows, areaCols, area);

        double damageDone = Convert.ToDouble(destroyedBunkers) / (Convert.ToDouble(areaRows) * Convert.ToDouble(areaCols)) * 100;

        Console.WriteLine($"Destroyed bunkers: {destroyedBunkers}");
        Console.WriteLine($"Damage done: {damageDone:0.0} %");

    }

    private static void CeaseFire(int areaRows, int areaCols, int[][] area)
    {
        var shot = Console.ReadLine();

        while (shot != "cease fire!")
        {
            var shotArgs = shot
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var shotRow = int.Parse(shotArgs[0]);
            var shotMaxRow = Math.Min(shotRow + 1, areaRows - 1);
            var shotMinRow = Math.Max(shotRow - 1, 0);

            var shotCol = int.Parse(shotArgs[1]);
            var shotMaxCol = Math.Min(shotCol + 1, areaCols - 1);
            var shotMinCol = Math.Max(shotCol - 1, 0);

            var shotStrength = (int)Convert.ToChar(shotArgs[2]);
            var shotStrenghtHalf = (shotStrength - 1) / 2 + 1;

            for (int row = shotMinRow; row <= shotMaxRow; row++)
            {
                for (int col = shotMinCol; col <= shotMaxCol; col++)
                {
                    if (area[row][col] <= 0)
                    {
                        continue;
                    }

                    if (row == shotRow && col == shotCol)
                    {
                        area[row][col] -= shotStrength;
                    }
                    else
                    {
                        area[row][col] -= shotStrenghtHalf;
                    }

                    if (area[row][col] <= 0)
                    {
                        destroyedBunkers++;
                    }
                }
            }

            shot = Console.ReadLine();
        }
    }

    private static void FillArea(int areaRows, int[][] area)
    {
        for (int i = 0; i < areaRows; i++)
        {
            area[i] = Console.ReadLine()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
        }
    }
}